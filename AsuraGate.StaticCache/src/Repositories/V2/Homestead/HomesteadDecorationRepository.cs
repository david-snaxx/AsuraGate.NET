using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities.V2.Homestead;
using AsuraGate.StaticCache.Mappers.V2.Homestead;

namespace AsuraGate.StaticCache.Repositories.V2.Homestead;

public class HomesteadDecorationRepository :
    IStaticCacheRepository<HomesteadDecoration, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public HomesteadDecorationRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<HomesteadDecoration?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<HomesteadDecorationEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var categoryEntities = await _database.Connection.Table<HomesteadDecorationCategoryLinkEntity>().Where(category => category.HomesteadDecorationId == id).ToListAsync();
        return HomesteadDecorationMapper.ToModel(entity, categoryEntities);
    }

    public async Task<IEnumerable<HomesteadDecoration>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<HomesteadDecorationEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var categoryEntities = await _database.Connection
            .Table<HomesteadDecorationCategoryLinkEntity>()
            .Where(category => idList.Contains(category.HomesteadDecorationId))
            .ToListAsync();

        return entities.Select(entity => HomesteadDecorationMapper.ToModel(entity, categoryEntities.Where(category => category.HomesteadDecorationId == entity.Id)));
    }

    public async Task<IEnumerable<HomesteadDecoration>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<HomesteadDecorationEntity>().ToListAsync();
        var categoryEntities = await _database.Connection.Table<HomesteadDecorationCategoryLinkEntity>().ToListAsync();

        return entities.Select(entity => HomesteadDecorationMapper.ToModel(entity, categoryEntities.Where(category => category.HomesteadDecorationId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<HomesteadDecorationEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(HomesteadDecoration decoration) => UpsertAllAsync([decoration]);

    public Task UpsertAllAsync(IEnumerable<HomesteadDecoration> decorations) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var decoration in decorations)
        {
            connection.InsertOrReplace(HomesteadDecorationMapper.ToHomesteadDecorationEntity(decoration));
            connection.Table<HomesteadDecorationCategoryLinkEntity>().Delete(category => category.HomesteadDecorationId == decoration.Id);
            connection.InsertAll(HomesteadDecorationMapper.ToCategoryEntities(decoration));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<HomesteadDecorationCategoryLinkEntity>().Delete(category => category.HomesteadDecorationId == id);
        connection.Delete<HomesteadDecorationEntity>(id);
    });
}
