using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;
using AsuraGate.StaticCache.Mappers.V2.Guild;

namespace AsuraGate.StaticCache.Repositories.V2.Guild;

public class GuildUpgradeRepository :
    IStaticCacheRepository<GuildUpgrade, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public GuildUpgradeRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<GuildUpgrade?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<GuildUpgradeEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var prerequisiteEntities = await _database.Connection.Table<GuildUpgradePrerequisiteEntity>().Where(prerequisite => prerequisite.GuildUpgradeId == id).ToListAsync();
        var costEntities = await _database.Connection.Table<GuildUpgradeCostEntity>().Where(cost => cost.GuildUpgradeId == id).ToListAsync();
        return GuildUpgradeMapper.ToModel(entity, prerequisiteEntities, costEntities);
    }

    public async Task<IEnumerable<GuildUpgrade>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<GuildUpgradeEntity>().ToListAsync();
        var prerequisiteEntities = await _database.Connection.Table<GuildUpgradePrerequisiteEntity>().ToListAsync();
        var costEntities = await _database.Connection.Table<GuildUpgradeCostEntity>().ToListAsync();

        return entities.Select(entity => GuildUpgradeMapper.ToModel(
            entity,
            prerequisiteEntities.Where(prerequisite => prerequisite.GuildUpgradeId == entity.Id),
            costEntities.Where(cost => cost.GuildUpgradeId == entity.Id)));
    }

    public Task UpsertAsync(GuildUpgrade upgrade) => UpsertAllAsync([upgrade]);

    public Task UpsertAllAsync(IEnumerable<GuildUpgrade> upgrades) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var upgrade in upgrades)
        {
            connection.InsertOrReplace(GuildUpgradeMapper.ToGuildUpgradeEntity(upgrade));
            connection.Table<GuildUpgradePrerequisiteEntity>().Delete(prerequisite => prerequisite.GuildUpgradeId == upgrade.Id);
            connection.InsertAll(GuildUpgradeMapper.ToPrerequisiteEntities(upgrade));
            connection.Table<GuildUpgradeCostEntity>().Delete(cost => cost.GuildUpgradeId == upgrade.Id);
            connection.InsertAll(GuildUpgradeMapper.ToCostEntities(upgrade));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<GuildUpgradePrerequisiteEntity>().Delete(prerequisite => prerequisite.GuildUpgradeId == id);
        connection.Table<GuildUpgradeCostEntity>().Delete(cost => cost.GuildUpgradeId == id);
        connection.Delete<GuildUpgradeEntity>(id);
    });
}
