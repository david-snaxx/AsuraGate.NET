using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;
using AsuraGate.StaticCache.Mappers.V2.Wvw;

namespace AsuraGate.StaticCache.Repositories.V2.Wvw;

public class WvwRankRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WvwRankRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<WvwRank?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<WvwRankEntity>(id);
        return entity is null ? null : WvwRankMapper.ToModel(entity);
    }

    public async Task<IEnumerable<WvwRank>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WvwRankEntity>().ToListAsync();
        return entities.Select(WvwRankMapper.ToModel);
    }

    public Task UpsertAsync(WvwRank rank) => UpsertAllAsync([rank]);

    public Task UpsertAllAsync(IEnumerable<WvwRank> ranks) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var rank in ranks)
        {
            connection.InsertOrReplace(WvwRankMapper.ToWvwRankEntity(rank));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<WvwRankEntity>(id);
}
