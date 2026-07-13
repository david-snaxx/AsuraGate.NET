using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;
using AsuraGate.StaticCache.Mappers.V2.Wvw;

namespace AsuraGate.StaticCache.Repositories.V2.Wvw;

public class WvwObjectiveRepository :
    IStaticCacheRepository<WvwObjective, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WvwObjectiveRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<WvwObjective?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<WvwObjectiveEntity>(id);
        return entity is null ? null : WvwObjectiveMapper.ToModel(entity);
    }
    
    public async Task<IEnumerable<WvwObjective>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<WvwObjectiveEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(WvwObjectiveMapper.ToModel);
    }

    public async Task<IEnumerable<WvwObjective>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WvwObjectiveEntity>().ToListAsync();
        return entities.Select(WvwObjectiveMapper.ToModel);
    }

    public async Task<IEnumerable<string>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<WvwObjectiveEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(WvwObjective objective) => UpsertAllAsync([objective]);

    public Task UpsertAllAsync(IEnumerable<WvwObjective> objectives) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var objective in objectives)
        {
            connection.InsertOrReplace(WvwObjectiveMapper.ToWvwObjectiveEntity(objective));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<WvwObjectiveEntity>(id);
}
