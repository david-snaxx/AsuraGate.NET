using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class WorldRepository :
    IStaticCacheRepository<World, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WorldRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<World?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<WorldEntity>(id);
        return entity is null ? null : WorldMapper.ToModel(entity);
    }

    public async Task<IEnumerable<World>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WorldEntity>().ToListAsync();
        return entities.Select(WorldMapper.ToModel);
    }

    public Task UpsertAsync(World world) => UpsertAllAsync([world]);

    public Task UpsertAllAsync(IEnumerable<World> worlds) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var world in worlds)
        {
            connection.InsertOrReplace(WorldMapper.ToWorldEntity(world));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<WorldEntity>(id);
}
