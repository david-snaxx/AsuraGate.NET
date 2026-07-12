using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ItemStatRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ItemStatRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<ItemStat?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<ItemStatEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var attributeEntities = await _database.Connection.Table<ItemStatAttributeEntity>().Where(attribute => attribute.ItemStatId == id).ToListAsync();
        return ItemStatMapper.ToModel(entity, attributeEntities);
    }

    public async Task<IEnumerable<ItemStat>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ItemStatEntity>().ToListAsync();
        var attributeEntities = await _database.Connection.Table<ItemStatAttributeEntity>().ToListAsync();

        return entities.Select(entity => ItemStatMapper.ToModel(entity, attributeEntities.Where(attribute => attribute.ItemStatId == entity.Id)));
    }

    public Task UpsertAsync(ItemStat itemStat) => UpsertAllAsync([itemStat]);

    public Task UpsertAllAsync(IEnumerable<ItemStat> itemStats) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var itemStat in itemStats)
        {
            connection.InsertOrReplace(ItemStatMapper.ToItemStatEntity(itemStat));
            connection.Table<ItemStatAttributeEntity>().Delete(attribute => attribute.ItemStatId == itemStat.Id);
            connection.InsertAll(ItemStatMapper.ToAttributeEntities(itemStat));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<ItemStatAttributeEntity>().Delete(attribute => attribute.ItemStatId == id);
        connection.Delete<ItemStatEntity>(id);
    });
}
