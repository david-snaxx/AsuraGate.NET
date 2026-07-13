using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class LegendaryArmoryItemRepository :
    IStaticCacheRepository<LegendaryArmoryItem, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public LegendaryArmoryItemRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<LegendaryArmoryItem?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<LegendaryArmoryItemEntity>(id);
        return entity is null ? null : LegendaryArmoryItemMapper.ToModel(entity);
    }

    public async Task<IEnumerable<LegendaryArmoryItem>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<LegendaryArmoryItemEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(LegendaryArmoryItemMapper.ToModel);
    }

    public async Task<IEnumerable<LegendaryArmoryItem>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<LegendaryArmoryItemEntity>().ToListAsync();
        return entities.Select(LegendaryArmoryItemMapper.ToModel);
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<LegendaryArmoryItemEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(LegendaryArmoryItem item) => UpsertAllAsync([item]);

    public Task UpsertAllAsync(IEnumerable<LegendaryArmoryItem> items) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var item in items)
        {
            connection.InsertOrReplace(LegendaryArmoryItemMapper.ToLegendaryArmoryItemEntity(item));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<LegendaryArmoryItemEntity>(id);
}
