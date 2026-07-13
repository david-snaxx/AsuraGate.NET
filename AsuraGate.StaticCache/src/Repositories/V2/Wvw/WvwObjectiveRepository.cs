using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;
using AsuraGate.StaticCache.Mappers.V2.Wvw;

namespace AsuraGate.StaticCache.Repositories.V2.Wvw;

public class WvwObjectiveRepository :
    IStaticCacheRepository<WvwObjective, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WvwObjectiveRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<WvwObjective?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<WvwObjectiveEntity>(id);
        return entity is null ? null : WvwObjectiveMapper.ToModel(entity);
    }

    public async Task<IEnumerable<WvwObjective>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WvwObjectiveEntity>().ToListAsync();
        return entities.Select(WvwObjectiveMapper.ToModel);
    }

    public Task UpsertAsync(WvwObjective objective) => UpsertAllAsync([objective]);

    public Task UpsertAllAsync(IEnumerable<WvwObjective> objectives) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var objective in objectives)
        {
            connection.InsertOrReplace(WvwObjectiveMapper.ToWvwObjectiveEntity(objective));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<WvwObjectiveEntity>(id);
}
