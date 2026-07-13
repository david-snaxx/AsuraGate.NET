using AsuraGate.Spec.Models.V2.Wvw;
using AsuraGate.StaticCache.Entities.V2.Wvw;
using AsuraGate.StaticCache.Mappers.V2.Wvw;

namespace AsuraGate.StaticCache.Repositories.V2.Wvw;

public class WvwAbilityRepository :
    IStaticCacheRepository<WvwAbility, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public WvwAbilityRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<WvwAbility?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<WvwAbilityEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var rankEntities = await _database.Connection.Table<WvwAbilityRankEntity>().Where(rank => rank.WvwAbilityId == id).ToListAsync();
        return WvwAbilityMapper.ToModel(entity, rankEntities);
    }

    public async Task<IEnumerable<WvwAbility>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<WvwAbilityEntity>().ToListAsync();
        var rankEntities = await _database.Connection.Table<WvwAbilityRankEntity>().ToListAsync();

        return entities.Select(entity => WvwAbilityMapper.ToModel(entity, rankEntities.Where(rank => rank.WvwAbilityId == entity.Id)));
    }

    public Task UpsertAsync(WvwAbility ability) => UpsertAllAsync([ability]);

    public Task UpsertAllAsync(IEnumerable<WvwAbility> abilities) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var ability in abilities)
        {
            connection.InsertOrReplace(WvwAbilityMapper.ToWvwAbilityEntity(ability));
            connection.Table<WvwAbilityRankEntity>().Delete(rank => rank.WvwAbilityId == ability.Id);
            connection.InsertAll(WvwAbilityMapper.ToRankEntities(ability));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<WvwAbilityRankEntity>().Delete(rank => rank.WvwAbilityId == id);
        connection.Delete<WvwAbilityEntity>(id);
    });
}
