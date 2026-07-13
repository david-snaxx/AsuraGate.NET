using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class HomeCatRepository :
    IStaticCacheRepository<HomeCat, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public HomeCatRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<HomeCat?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<HomeCatEntity>(id);
        return entity is null ? null : HomeCatMapper.ToModel(entity);
    }

    public async Task<IEnumerable<HomeCat>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<HomeCatEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(HomeCatMapper.ToModel);
    }

    public async Task<IEnumerable<HomeCat>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<HomeCatEntity>().ToListAsync();
        return entities.Select(HomeCatMapper.ToModel);
    }

    public Task UpsertAsync(HomeCat homeCat) => UpsertAllAsync([homeCat]);

    public Task UpsertAllAsync(IEnumerable<HomeCat> homeCats) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var homeCat in homeCats)
        {
            connection.InsertOrReplace(HomeCatMapper.ToHomeCatEntity(homeCat));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<HomeCatEntity>(id);
}
