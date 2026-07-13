using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class QuagganRepository :
    IStaticCacheRepository<Quaggan, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public QuagganRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Quaggan?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<QuagganEntity>(id);
        return entity is null ? null : QuagganMapper.ToModel(entity);
    }

    public async Task<IEnumerable<Quaggan>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<QuagganEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(QuagganMapper.ToModel);
    }

    public async Task<IEnumerable<Quaggan>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<QuagganEntity>().ToListAsync();
        return entities.Select(QuagganMapper.ToModel);
    }

    public async Task<IEnumerable<string>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<QuagganEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Quaggan quaggan) => UpsertAllAsync([quaggan]);

    public Task UpsertAllAsync(IEnumerable<Quaggan> quaggans) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var quaggan in quaggans)
        {
            connection.InsertOrReplace(QuagganMapper.ToQuagganEntity(quaggan));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<QuagganEntity>(id);
}
