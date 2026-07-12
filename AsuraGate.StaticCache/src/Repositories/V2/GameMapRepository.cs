using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class GameMapRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public GameMapRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<GameMap?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<GameMapEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var floorEntities = await _database.Connection.Table<GameMapFloorEntity>().Where(floor => floor.GameMapId == id).ToListAsync();
        return GameMapMapper.ToModel(entity, floorEntities);
    }

    public async Task<IEnumerable<GameMap>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<GameMapEntity>().ToListAsync();
        var floorEntities = await _database.Connection.Table<GameMapFloorEntity>().ToListAsync();

        return entities.Select(entity => GameMapMapper.ToModel(entity, floorEntities.Where(floor => floor.GameMapId == entity.Id)));
    }

    public Task UpsertAsync(GameMap gameMap) => UpsertAllAsync([gameMap]);

    public Task UpsertAllAsync(IEnumerable<GameMap> gameMaps) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var gameMap in gameMaps)
        {
            connection.InsertOrReplace(GameMapMapper.ToGameMapEntity(gameMap));
            connection.Table<GameMapFloorEntity>().Delete(floor => floor.GameMapId == gameMap.Id);
            connection.InsertAll(GameMapMapper.ToFloorEntities(gameMap));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<GameMapFloorEntity>().Delete(floor => floor.GameMapId == id);
        connection.Delete<GameMapEntity>(id);
    });
}
