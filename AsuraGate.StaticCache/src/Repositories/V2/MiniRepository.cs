using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class MiniRepository :
    IStaticCacheRepository<Mini, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public MiniRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Mini?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<MiniEntity>(id);
        return entity is null ? null : MiniMapper.ToModel(entity);
    }

    public async Task<IEnumerable<Mini>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<MiniEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(MiniMapper.ToModel);
    }

    public async Task<IEnumerable<Mini>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<MiniEntity>().ToListAsync();
        return entities.Select(MiniMapper.ToModel);
    }

    public Task UpsertAsync(Mini mini) => UpsertAllAsync([mini]);

    public Task UpsertAllAsync(IEnumerable<Mini> minis) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var mini in minis)
        {
            connection.InsertOrReplace(MiniMapper.ToMiniEntity(mini));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<MiniEntity>(id);
}
