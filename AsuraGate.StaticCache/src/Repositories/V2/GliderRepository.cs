using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class GliderRepository :
    IStaticCacheRepository<Glider, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public GliderRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Glider?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<GliderEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var unlockItemEntities = await _database.Connection.Table<GliderUnlockItemEntity>().Where(item => item.GliderId == id).ToListAsync();
        var defaultDyeEntities = await _database.Connection.Table<GliderDefaultDyeEntity>().Where(dye => dye.GliderId == id).ToListAsync();
        return GliderMapper.ToModel(entity, unlockItemEntities, defaultDyeEntities);
    }

    public async Task<IEnumerable<Glider>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<GliderEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<GliderUnlockItemEntity>().ToListAsync();
        var defaultDyeEntities = await _database.Connection.Table<GliderDefaultDyeEntity>().ToListAsync();

        return entities.Select(entity => GliderMapper.ToModel(
            entity,
            unlockItemEntities.Where(item => item.GliderId == entity.Id),
            defaultDyeEntities.Where(dye => dye.GliderId == entity.Id)));
    }

    public Task UpsertAsync(Glider glider) => UpsertAllAsync([glider]);

    public Task UpsertAllAsync(IEnumerable<Glider> gliders) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var glider in gliders)
        {
            connection.InsertOrReplace(GliderMapper.ToGliderEntity(glider));
            connection.Table<GliderUnlockItemEntity>().Delete(item => item.GliderId == glider.Id);
            connection.InsertAll(GliderMapper.ToUnlockItemEntities(glider));
            connection.Table<GliderDefaultDyeEntity>().Delete(dye => dye.GliderId == glider.Id);
            connection.InsertAll(GliderMapper.ToDefaultDyeEntities(glider));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<GliderUnlockItemEntity>().Delete(item => item.GliderId == id);
        connection.Table<GliderDefaultDyeEntity>().Delete(dye => dye.GliderId == id);
        connection.Delete<GliderEntity>(id);
    });
}
