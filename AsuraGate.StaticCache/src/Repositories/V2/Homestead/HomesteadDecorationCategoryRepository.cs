using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities.V2.Homestead;
using AsuraGate.StaticCache.Mappers.V2.Homestead;

namespace AsuraGate.StaticCache.Repositories.V2.Homestead;

public class HomesteadDecorationCategoryRepository :
    IStaticCacheRepository<HomesteadDecorationCategory, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public HomesteadDecorationCategoryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<HomesteadDecorationCategory?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<HomesteadDecorationCategoryEntity>(id);
        return entity is null ? null : HomesteadDecorationCategoryMapper.ToModel(entity);
    }

    public async Task<IEnumerable<HomesteadDecorationCategory>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<HomesteadDecorationCategoryEntity>().ToListAsync();
        return entities.Select(HomesteadDecorationCategoryMapper.ToModel);
    }

    public Task UpsertAsync(HomesteadDecorationCategory category) => UpsertAllAsync([category]);

    public Task UpsertAllAsync(IEnumerable<HomesteadDecorationCategory> categories) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var category in categories)
        {
            connection.InsertOrReplace(HomesteadDecorationCategoryMapper.ToHomesteadDecorationCategoryEntity(category));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<HomesteadDecorationCategoryEntity>(id);
}
