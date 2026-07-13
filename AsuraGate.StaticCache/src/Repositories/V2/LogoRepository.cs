using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class LogoRepository :
    IStaticCacheRepository<Logo, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public LogoRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Logo?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<LogoEntity>(id);
        return entity is null ? null : LogoMapper.ToModel(entity);
    }

    public async Task<IEnumerable<Logo>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<LogoEntity>().ToListAsync();
        return entities.Select(LogoMapper.ToModel);
    }

    public Task UpsertAsync(Logo logo) => UpsertAllAsync([logo]);

    public Task UpsertAllAsync(IEnumerable<Logo> logos) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var logo in logos)
        {
            connection.InsertOrReplace(LogoMapper.ToLogoEntity(logo));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<LogoEntity>(id);
}
