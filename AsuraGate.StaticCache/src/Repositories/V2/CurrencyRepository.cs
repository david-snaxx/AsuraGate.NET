using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class CurrencyRepository :
    IStaticCacheRepository<Currency, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public CurrencyRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Currency?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<CurrencyEntity>(id);
        return entity is null ? null : CurrencyMapper.ToModel(entity);
    }

    public async Task<IEnumerable<Currency>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<CurrencyEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(CurrencyMapper.ToModel);
    }

    public async Task<IEnumerable<Currency>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<CurrencyEntity>().ToListAsync();
        return entities.Select(CurrencyMapper.ToModel);
    }

    public Task UpsertAsync(Currency currency) => UpsertAllAsync([currency]);

    public Task UpsertAllAsync(IEnumerable<Currency> currencies) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var currency in currencies)
        {
            connection.InsertOrReplace(CurrencyMapper.ToCurrencyEntity(currency));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<CurrencyEntity>(id);
}
