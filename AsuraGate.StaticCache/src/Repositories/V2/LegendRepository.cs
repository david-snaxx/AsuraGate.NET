using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class LegendRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public LegendRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Legend?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<LegendEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var utilityEntities = await _database.Connection.Table<LegendUtilityEntity>().Where(utility => utility.LegendId == id).ToListAsync();
        return LegendMapper.ToModel(entity, utilityEntities);
    }

    public async Task<IEnumerable<Legend>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<LegendEntity>().ToListAsync();
        var utilityEntities = await _database.Connection.Table<LegendUtilityEntity>().ToListAsync();

        return entities.Select(entity => LegendMapper.ToModel(entity, utilityEntities.Where(utility => utility.LegendId == entity.Id)));
    }

    public Task UpsertAsync(Legend legend) => UpsertAllAsync([legend]);

    public Task UpsertAllAsync(IEnumerable<Legend> legends) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var legend in legends)
        {
            connection.InsertOrReplace(LegendMapper.ToLegendEntity(legend));
            connection.Table<LegendUtilityEntity>().Delete(utility => utility.LegendId == legend.Id);
            connection.InsertAll(LegendMapper.ToUtilityEntities(legend));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<LegendUtilityEntity>().Delete(utility => utility.LegendId == id);
        connection.Delete<LegendEntity>(id);
    });
}
