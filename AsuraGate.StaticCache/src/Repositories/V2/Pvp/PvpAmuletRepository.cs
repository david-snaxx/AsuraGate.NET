using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Pvp;
using AsuraGate.StaticCache.Mappers.V2.Pvp;

namespace AsuraGate.StaticCache.Repositories.V2.Pvp;

public class PvpAmuletRepository :
    IStaticCacheRepository<PvpAmulet, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public PvpAmuletRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<PvpAmulet?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<PvpAmuletEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var attributeEntities = await _database.Connection.Table<PvpAmuletAttributeEntity>().Where(attribute => attribute.PvpAmuletId == id).ToListAsync();
        return PvpAmuletMapper.ToModel(entity, attributeEntities);
    }

    public async Task<IEnumerable<PvpAmulet>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<PvpAmuletEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var attributeEntities = await _database.Connection
            .Table<PvpAmuletAttributeEntity>()
            .Where(attribute => idList.Contains(attribute.PvpAmuletId))
            .ToListAsync();

        return entities.Select(entity => PvpAmuletMapper.ToModel(entity, attributeEntities.Where(attribute => attribute.PvpAmuletId == entity.Id)));
    }

    public async Task<IEnumerable<PvpAmulet>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<PvpAmuletEntity>().ToListAsync();
        var attributeEntities = await _database.Connection.Table<PvpAmuletAttributeEntity>().ToListAsync();

        return entities.Select(entity => PvpAmuletMapper.ToModel(entity, attributeEntities.Where(attribute => attribute.PvpAmuletId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<PvpAmuletEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(PvpAmulet amulet) => UpsertAllAsync([amulet]);

    public Task UpsertAllAsync(IEnumerable<PvpAmulet> amulets) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var amulet in amulets)
        {
            connection.InsertOrReplace(PvpAmuletMapper.ToPvpAmuletEntity(amulet));
            connection.Table<PvpAmuletAttributeEntity>().Delete(attribute => attribute.PvpAmuletId == amulet.Id);
            connection.InsertAll(PvpAmuletMapper.ToAttributeEntities(amulet));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<PvpAmuletAttributeEntity>().Delete(attribute => attribute.PvpAmuletId == id);
        connection.Delete<PvpAmuletEntity>(id);
    });
}
