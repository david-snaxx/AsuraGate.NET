using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class JadeBotRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public JadeBotRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<JadeBot?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<JadeBotEntity>(id);
        return entity is null ? null : JadeBotMapper.ToModel(entity);
    }

    public async Task<IEnumerable<JadeBot>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<JadeBotEntity>().ToListAsync();
        return entities.Select(JadeBotMapper.ToModel);
    }

    public Task UpsertAsync(JadeBot jadeBot) => UpsertAllAsync([jadeBot]);

    public Task UpsertAllAsync(IEnumerable<JadeBot> jadeBots) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var jadeBot in jadeBots)
        {
            connection.InsertOrReplace(JadeBotMapper.ToJadeBotEntity(jadeBot));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<JadeBotEntity>(id);
}
