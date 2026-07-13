using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;
using AsuraGate.StaticCache.Mappers.V2.Wvw;

namespace AsuraGate.StaticCache.Repositories.V2.Wvw;

public class WvwUpgradeRepository :
    IStaticCacheRepository<WvwUpgrade, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WvwUpgradeRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<WvwUpgrade?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<WvwUpgradeEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var tierEntities = await _database.Connection.Table<WvwUpgradeTierEntity>().Where(tier => tier.WvwUpgradeId == id).ToListAsync();
        var itemEntities = await _database.Connection.Table<WvwUpgradeItemEntity>().Where(item => item.WvwUpgradeId == id).ToListAsync();
        return WvwUpgradeMapper.ToModel(entity, tierEntities, itemEntities);
    }

    public async Task<IEnumerable<WvwUpgrade>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<WvwUpgradeEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var tierEntities = await _database.Connection
            .Table<WvwUpgradeTierEntity>()
            .Where(tier => idList.Contains(tier.WvwUpgradeId))
            .ToListAsync();
        var itemEntities = await _database.Connection
            .Table<WvwUpgradeItemEntity>()
            .Where(item => idList.Contains(item.WvwUpgradeId))
            .ToListAsync();

        return entities.Select(entity => WvwUpgradeMapper.ToModel(
            entity,
            tierEntities.Where(tier => tier.WvwUpgradeId == entity.Id),
            itemEntities.Where(item => item.WvwUpgradeId == entity.Id)));
    }

    public async Task<IEnumerable<WvwUpgrade>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WvwUpgradeEntity>().ToListAsync();
        var tierEntities = await _database.Connection.Table<WvwUpgradeTierEntity>().ToListAsync();
        var itemEntities = await _database.Connection.Table<WvwUpgradeItemEntity>().ToListAsync();

        return entities.Select(entity => WvwUpgradeMapper.ToModel(
            entity,
            tierEntities.Where(tier => tier.WvwUpgradeId == entity.Id),
            itemEntities.Where(item => item.WvwUpgradeId == entity.Id)));
    }

    public Task UpsertAsync(WvwUpgrade upgrade) => UpsertAllAsync([upgrade]);

    public Task UpsertAllAsync(IEnumerable<WvwUpgrade> upgrades) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var upgrade in upgrades)
        {
            connection.InsertOrReplace(WvwUpgradeMapper.ToWvwUpgradeEntity(upgrade));
            connection.Table<WvwUpgradeTierEntity>().Delete(tier => tier.WvwUpgradeId == upgrade.Id);
            connection.InsertAll(WvwUpgradeMapper.ToTierEntities(upgrade));
            connection.Table<WvwUpgradeItemEntity>().Delete(item => item.WvwUpgradeId == upgrade.Id);
            connection.InsertAll(WvwUpgradeMapper.ToItemEntities(upgrade));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<WvwUpgradeTierEntity>().Delete(tier => tier.WvwUpgradeId == id);
        connection.Table<WvwUpgradeItemEntity>().Delete(item => item.WvwUpgradeId == id);
        connection.Delete<WvwUpgradeEntity>(id);
    });
}
