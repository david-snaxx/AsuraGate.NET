using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class SkinRepository :
    IStaticCacheRepository<Skin, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public SkinRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Skin?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<SkinEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var flagEntities = await _database.Connection.Table<SkinFlagEntity>().Where(flag => flag.SkinId == id).ToListAsync();
        var restrictionEntities = await _database.Connection.Table<SkinRestrictionEntity>().Where(restriction => restriction.SkinId == id).ToListAsync();
        var detailsEntity = await _database.Connection.Table<SkinDetailsEntity>().Where(details => details.SkinId == id).FirstOrDefaultAsync();
        var defaultDyeSlotEntities = await _database.Connection.Table<SkinDefaultDyeSlotEntity>().Where(slot => slot.SkinId == id).ToListAsync();

        return SkinMapper.ToModel(entity, flagEntities, restrictionEntities, detailsEntity, defaultDyeSlotEntities);
    }

    public async Task<IEnumerable<Skin>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<SkinEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var flagEntities = await _database.Connection
            .Table<SkinFlagEntity>()
            .Where(flag => idList.Contains(flag.SkinId))
            .ToListAsync();
        var restrictionEntities = await _database.Connection
            .Table<SkinRestrictionEntity>()
            .Where(restriction => idList.Contains(restriction.SkinId))
            .ToListAsync();
        var detailsEntities = await _database.Connection
            .Table<SkinDetailsEntity>()
            .Where(details => idList.Contains(details.SkinId))
            .ToListAsync();
        var defaultDyeSlotEntities = await _database.Connection
            .Table<SkinDefaultDyeSlotEntity>()
            .Where(slot => idList.Contains(slot.SkinId))
            .ToListAsync();

        return entities.Select(entity => SkinMapper.ToModel(
            entity,
            flagEntities.Where(flag => flag.SkinId == entity.Id),
            restrictionEntities.Where(restriction => restriction.SkinId == entity.Id),
            detailsEntities.FirstOrDefault(details => details.SkinId == entity.Id),
            defaultDyeSlotEntities.Where(slot => slot.SkinId == entity.Id)));
    }

    public async Task<IEnumerable<Skin>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<SkinEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<SkinFlagEntity>().ToListAsync();
        var restrictionEntities = await _database.Connection.Table<SkinRestrictionEntity>().ToListAsync();
        var detailsEntities = await _database.Connection.Table<SkinDetailsEntity>().ToListAsync();
        var defaultDyeSlotEntities = await _database.Connection.Table<SkinDefaultDyeSlotEntity>().ToListAsync();

        return entities.Select(entity => SkinMapper.ToModel(
            entity,
            flagEntities.Where(flag => flag.SkinId == entity.Id),
            restrictionEntities.Where(restriction => restriction.SkinId == entity.Id),
            detailsEntities.FirstOrDefault(details => details.SkinId == entity.Id),
            defaultDyeSlotEntities.Where(slot => slot.SkinId == entity.Id)));
    }

    public Task UpsertAsync(Skin skin) => UpsertAllAsync([skin]);

    public Task UpsertAllAsync(IEnumerable<Skin> skins) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var skin in skins)
        {
            connection.InsertOrReplace(SkinMapper.ToSkinEntity(skin));

            connection.Table<SkinFlagEntity>().Delete(flag => flag.SkinId == skin.Id);
            connection.InsertAll(SkinMapper.ToFlagEntities(skin));

            connection.Table<SkinRestrictionEntity>().Delete(restriction => restriction.SkinId == skin.Id);
            connection.InsertAll(SkinMapper.ToRestrictionEntities(skin));

            connection.Table<SkinDetailsEntity>().Delete(details => details.SkinId == skin.Id);
            var detailsEntity = SkinMapper.ToDetailsEntity(skin);
            if (detailsEntity is not null)
            {
                connection.Insert(detailsEntity);
            }

            connection.Table<SkinDefaultDyeSlotEntity>().Delete(slot => slot.SkinId == skin.Id);
            connection.InsertAll(SkinMapper.ToDefaultDyeSlotEntities(skin));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<SkinFlagEntity>().Delete(flag => flag.SkinId == id);
        connection.Table<SkinRestrictionEntity>().Delete(restriction => restriction.SkinId == id);
        connection.Table<SkinDetailsEntity>().Delete(details => details.SkinId == id);
        connection.Table<SkinDefaultDyeSlotEntity>().Delete(slot => slot.SkinId == id);
        connection.Delete<SkinEntity>(id);
    });
}
