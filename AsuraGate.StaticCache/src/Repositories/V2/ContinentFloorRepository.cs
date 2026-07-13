using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ContinentFloorRepository :
    IStaticCacheRepository<ContinentFloor, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ContinentFloorRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<ContinentFloor?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<ContinentFloorEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var regionEntities = await _database.Connection.Table<ContinentFloorRegionEntity>().Where(region => region.FloorId == id).ToListAsync();
        var mapEntities = await _database.Connection.Table<ContinentFloorMapEntity>().Where(map => map.FloorId == id).ToListAsync();
        var mapKeys = mapEntities.Select(map => map.MapKey).ToList();

        var godShrineEntities = await _database.Connection.Table<ContinentFloorGodShrineEntity>().Where(shrine => mapKeys.Contains(shrine.MapKey)).ToListAsync();
        var pointOfInterestEntities = await _database.Connection.Table<ContinentFloorPointOfInterestEntity>().Where(poi => mapKeys.Contains(poi.MapKey)).ToListAsync();
        var taskEntities = await _database.Connection.Table<ContinentFloorTaskEntity>().Where(task => mapKeys.Contains(task.MapKey)).ToListAsync();
        var taskKeys = taskEntities.Select(task => task.TaskKey).ToList();
        var taskBoundsPointEntities = await _database.Connection.Table<ContinentFloorTaskBoundsPointEntity>().Where(point => taskKeys.Contains(point.TaskKey)).ToListAsync();
        var skillChallengeEntities = await _database.Connection.Table<ContinentFloorSkillChallengeEntity>().Where(challenge => mapKeys.Contains(challenge.MapKey)).ToListAsync();
        var sectorEntities = await _database.Connection.Table<ContinentFloorSectorEntity>().Where(sector => mapKeys.Contains(sector.MapKey)).ToListAsync();
        var sectorKeys = sectorEntities.Select(sector => sector.SectorKey).ToList();
        var sectorBoundsPointEntities = await _database.Connection.Table<ContinentFloorSectorBoundsPointEntity>().Where(point => sectorKeys.Contains(point.SectorKey)).ToListAsync();
        var adventureEntities = await _database.Connection.Table<ContinentFloorAdventureEntity>().Where(adventure => mapKeys.Contains(adventure.MapKey)).ToListAsync();
        var masteryPointEntities = await _database.Connection.Table<ContinentFloorMasteryPointEntity>().Where(point => mapKeys.Contains(point.MapKey)).ToListAsync();

        return ContinentFloorMapper.ToModel(
            entity,
            regionEntities,
            mapEntities,
            godShrineEntities,
            pointOfInterestEntities,
            taskEntities,
            taskBoundsPointEntities,
            skillChallengeEntities,
            sectorEntities,
            sectorBoundsPointEntities,
            adventureEntities,
            masteryPointEntities);
    }

    public async Task<IEnumerable<ContinentFloor>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<ContinentFloorEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var regionEntities = await _database.Connection
            .Table<ContinentFloorRegionEntity>()
            .Where(region => idList.Contains(region.FloorId))
            .ToListAsync();
        var mapEntities = await _database.Connection
            .Table<ContinentFloorMapEntity>()
            .Where(map => idList.Contains(map.FloorId))
            .ToListAsync();
        var mapKeys = mapEntities
            .Select(map => map.MapKey)
            .ToList();

        var godShrineEntities = await _database.Connection
            .Table<ContinentFloorGodShrineEntity>()
            .Where(shrine => mapKeys.Contains(shrine.MapKey))
            .ToListAsync();
        var pointOfInterestEntities = await _database.Connection
            .Table<ContinentFloorPointOfInterestEntity>()
            .Where(poi => mapKeys.Contains(poi.MapKey))
            .ToListAsync();
        var taskEntities = await _database.Connection
            .Table<ContinentFloorTaskEntity>()
            .Where(task => mapKeys.Contains(task.MapKey))
            .ToListAsync();
        var taskKeys = taskEntities
            .Select(task => task.TaskKey)
            .ToList();
        var taskBoundsPointEntities = await _database.Connection
            .Table<ContinentFloorTaskBoundsPointEntity>()
            .Where(point => taskKeys.Contains(point.TaskKey))
            .ToListAsync();
        var skillChallengeEntities = await _database.Connection
            .Table<ContinentFloorSkillChallengeEntity>()
            .Where(challenge => mapKeys.Contains(challenge.MapKey))
            .ToListAsync();
        var sectorEntities = await _database.Connection
            .Table<ContinentFloorSectorEntity>()
            .Where(sector => mapKeys.Contains(sector.MapKey))
            .ToListAsync();
        var sectorKeys = sectorEntities
            .Select(sector => sector.SectorKey)
            .ToList();
        var sectorBoundsPointEntities = await _database.Connection
            .Table<ContinentFloorSectorBoundsPointEntity>()
            .Where(point => sectorKeys.Contains(point.SectorKey))
            .ToListAsync();
        var adventureEntities = await _database.Connection
            .Table<ContinentFloorAdventureEntity>()
            .Where(adventure => mapKeys.Contains(adventure.MapKey))
            .ToListAsync();
        var masteryPointEntities = await _database.Connection
            .Table<ContinentFloorMasteryPointEntity>()
            .Where(point => mapKeys.Contains(point.MapKey))
            .ToListAsync();
        
        return entities.Select(entity =>
        {
            var batchMapKeys = mapEntities
                .Where(map => map.FloorId == entity.Id)
                .Select(map => map.MapKey)
                .ToHashSet();
            var tasksForFloor = taskEntities
                .Where(task => batchMapKeys.Contains(task.MapKey))
                .ToList();
            var batchTaskKeys = tasksForFloor
                .Select(task => task.TaskKey)
                .ToHashSet();
            var sectorsForFloor = sectorEntities
                .Where(sector => batchMapKeys.Contains(sector.MapKey))
                .ToList();
            var batchSectorKeys = sectorsForFloor
                .Select(sector => sector.SectorKey)
                .ToHashSet();

            return ContinentFloorMapper.ToModel(
                entity,
                regionEntities.Where(region => region.FloorId == entity.Id),
                mapEntities.Where(map => map.FloorId == entity.Id),
                godShrineEntities.Where(shrine => batchMapKeys.Contains(shrine.MapKey)),
                pointOfInterestEntities.Where(poi => batchMapKeys.Contains(poi.MapKey)),
                tasksForFloor,
                taskBoundsPointEntities.Where(point => batchTaskKeys.Contains(point.TaskKey)),
                skillChallengeEntities.Where(challenge => batchMapKeys.Contains(challenge.MapKey)),
                sectorsForFloor,
                sectorBoundsPointEntities.Where(point => batchSectorKeys.Contains(point.SectorKey)),
                adventureEntities.Where(adventure => batchMapKeys.Contains(adventure.MapKey)),
                masteryPointEntities.Where(point => batchMapKeys.Contains(point.MapKey)));
        });
    }

    public async Task<IEnumerable<ContinentFloor>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ContinentFloorEntity>().ToListAsync();
        var regionEntities = await _database.Connection.Table<ContinentFloorRegionEntity>().ToListAsync();
        var mapEntities = await _database.Connection.Table<ContinentFloorMapEntity>().ToListAsync();
        var godShrineEntities = await _database.Connection.Table<ContinentFloorGodShrineEntity>().ToListAsync();
        var pointOfInterestEntities = await _database.Connection.Table<ContinentFloorPointOfInterestEntity>().ToListAsync();
        var taskEntities = await _database.Connection.Table<ContinentFloorTaskEntity>().ToListAsync();
        var taskBoundsPointEntities = await _database.Connection.Table<ContinentFloorTaskBoundsPointEntity>().ToListAsync();
        var skillChallengeEntities = await _database.Connection.Table<ContinentFloorSkillChallengeEntity>().ToListAsync();
        var sectorEntities = await _database.Connection.Table<ContinentFloorSectorEntity>().ToListAsync();
        var sectorBoundsPointEntities = await _database.Connection.Table<ContinentFloorSectorBoundsPointEntity>().ToListAsync();
        var adventureEntities = await _database.Connection.Table<ContinentFloorAdventureEntity>().ToListAsync();
        var masteryPointEntities = await _database.Connection.Table<ContinentFloorMasteryPointEntity>().ToListAsync();

        return entities.Select(entity =>
        {
            var mapKeys = mapEntities.Where(map => map.FloorId == entity.Id).Select(map => map.MapKey).ToHashSet();
            var tasksForFloor = taskEntities.Where(task => mapKeys.Contains(task.MapKey)).ToList();
            var taskKeys = tasksForFloor.Select(task => task.TaskKey).ToHashSet();
            var sectorsForFloor = sectorEntities.Where(sector => mapKeys.Contains(sector.MapKey)).ToList();
            var sectorKeys = sectorsForFloor.Select(sector => sector.SectorKey).ToHashSet();

            return ContinentFloorMapper.ToModel(
                entity,
                regionEntities.Where(region => region.FloorId == entity.Id),
                mapEntities.Where(map => map.FloorId == entity.Id),
                godShrineEntities.Where(shrine => mapKeys.Contains(shrine.MapKey)),
                pointOfInterestEntities.Where(poi => mapKeys.Contains(poi.MapKey)),
                tasksForFloor,
                taskBoundsPointEntities.Where(point => taskKeys.Contains(point.TaskKey)),
                skillChallengeEntities.Where(challenge => mapKeys.Contains(challenge.MapKey)),
                sectorsForFloor,
                sectorBoundsPointEntities.Where(point => sectorKeys.Contains(point.SectorKey)),
                adventureEntities.Where(adventure => mapKeys.Contains(adventure.MapKey)),
                masteryPointEntities.Where(point => mapKeys.Contains(point.MapKey)));
        });
    }

    public Task UpsertAsync(ContinentFloor floor) => UpsertAllAsync([floor]);

    public Task UpsertAllAsync(IEnumerable<ContinentFloor> floors) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var floor in floors)
        {
            var oldMapKeys = connection.Table<ContinentFloorMapEntity>().Where(map => map.FloorId == floor.Id).ToList().Select(map => map.MapKey).ToList();
            var oldTaskKeys = connection.Table<ContinentFloorTaskEntity>().Where(task => oldMapKeys.Contains(task.MapKey)).ToList().Select(task => task.TaskKey).ToList();
            var oldSectorKeys = connection.Table<ContinentFloorSectorEntity>().Where(sector => oldMapKeys.Contains(sector.MapKey)).ToList().Select(sector => sector.SectorKey).ToList();

            connection.Table<ContinentFloorTaskBoundsPointEntity>().Delete(point => oldTaskKeys.Contains(point.TaskKey));
            connection.Table<ContinentFloorSectorBoundsPointEntity>().Delete(point => oldSectorKeys.Contains(point.SectorKey));
            connection.Table<ContinentFloorGodShrineEntity>().Delete(shrine => oldMapKeys.Contains(shrine.MapKey));
            connection.Table<ContinentFloorPointOfInterestEntity>().Delete(poi => oldMapKeys.Contains(poi.MapKey));
            connection.Table<ContinentFloorTaskEntity>().Delete(task => oldMapKeys.Contains(task.MapKey));
            connection.Table<ContinentFloorSkillChallengeEntity>().Delete(challenge => oldMapKeys.Contains(challenge.MapKey));
            connection.Table<ContinentFloorSectorEntity>().Delete(sector => oldMapKeys.Contains(sector.MapKey));
            connection.Table<ContinentFloorAdventureEntity>().Delete(adventure => oldMapKeys.Contains(adventure.MapKey));
            connection.Table<ContinentFloorMasteryPointEntity>().Delete(point => oldMapKeys.Contains(point.MapKey));
            connection.Table<ContinentFloorMapEntity>().Delete(map => map.FloorId == floor.Id);
            connection.Table<ContinentFloorRegionEntity>().Delete(region => region.FloorId == floor.Id);

            connection.InsertOrReplace(ContinentFloorMapper.ToContinentFloorEntity(floor));
            connection.InsertAll(ContinentFloorMapper.ToRegionEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToMapEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToGodShrineEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToPointOfInterestEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToTaskEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToTaskBoundsPointEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToSkillChallengeEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToSectorEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToSectorBoundsPointEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToAdventureEntities(floor));
            connection.InsertAll(ContinentFloorMapper.ToMasteryPointEntities(floor));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        var mapKeys = connection.Table<ContinentFloorMapEntity>().Where(map => map.FloorId == id).ToList().Select(map => map.MapKey).ToList();
        var taskKeys = connection.Table<ContinentFloorTaskEntity>().Where(task => mapKeys.Contains(task.MapKey)).ToList().Select(task => task.TaskKey).ToList();
        var sectorKeys = connection.Table<ContinentFloorSectorEntity>().Where(sector => mapKeys.Contains(sector.MapKey)).ToList().Select(sector => sector.SectorKey).ToList();

        connection.Table<ContinentFloorTaskBoundsPointEntity>().Delete(point => taskKeys.Contains(point.TaskKey));
        connection.Table<ContinentFloorSectorBoundsPointEntity>().Delete(point => sectorKeys.Contains(point.SectorKey));
        connection.Table<ContinentFloorGodShrineEntity>().Delete(shrine => mapKeys.Contains(shrine.MapKey));
        connection.Table<ContinentFloorPointOfInterestEntity>().Delete(poi => mapKeys.Contains(poi.MapKey));
        connection.Table<ContinentFloorTaskEntity>().Delete(task => mapKeys.Contains(task.MapKey));
        connection.Table<ContinentFloorSkillChallengeEntity>().Delete(challenge => mapKeys.Contains(challenge.MapKey));
        connection.Table<ContinentFloorSectorEntity>().Delete(sector => mapKeys.Contains(sector.MapKey));
        connection.Table<ContinentFloorAdventureEntity>().Delete(adventure => mapKeys.Contains(adventure.MapKey));
        connection.Table<ContinentFloorMasteryPointEntity>().Delete(point => mapKeys.Contains(point.MapKey));
        connection.Table<ContinentFloorMapEntity>().Delete(map => map.FloorId == id);
        connection.Table<ContinentFloorRegionEntity>().Delete(region => region.FloorId == id);
        connection.Delete<ContinentFloorEntity>(id);
    });
}
