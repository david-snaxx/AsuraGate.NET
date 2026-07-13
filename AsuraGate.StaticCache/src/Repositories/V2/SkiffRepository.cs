using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class SkiffRepository :
    IStaticCacheRepository<Skiff, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public SkiffRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Skiff?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<SkiffEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var dyeSlotEntities = await _database.Connection.Table<SkiffDyeSlotEntity>().Where(slot => slot.SkiffId == id).ToListAsync();
        return SkiffMapper.ToModel(entity, dyeSlotEntities);
    }

    public async Task<IEnumerable<Skiff>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<SkiffEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var dyeSlotEntities = await _database.Connection
            .Table<SkiffDyeSlotEntity>()
            .Where(slot => idList.Contains(slot.SkiffId))
            .ToListAsync();

        return entities.Select(entity => SkiffMapper.ToModel(entity, dyeSlotEntities.Where(slot => slot.SkiffId == entity.Id)));
    }

    public async Task<IEnumerable<Skiff>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<SkiffEntity>().ToListAsync();
        var dyeSlotEntities = await _database.Connection.Table<SkiffDyeSlotEntity>().ToListAsync();

        return entities.Select(entity => SkiffMapper.ToModel(entity, dyeSlotEntities.Where(slot => slot.SkiffId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<SkiffEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Skiff skiff) => UpsertAllAsync([skiff]);

    public Task UpsertAllAsync(IEnumerable<Skiff> skiffs) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var skiff in skiffs)
        {
            connection.InsertOrReplace(SkiffMapper.ToSkiffEntity(skiff));
            connection.Table<SkiffDyeSlotEntity>().Delete(slot => slot.SkiffId == skiff.Id);
            connection.InsertAll(SkiffMapper.ToDyeSlotEntities(skiff));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<SkiffDyeSlotEntity>().Delete(slot => slot.SkiffId == id);
        connection.Delete<SkiffEntity>(id);
    });
}
