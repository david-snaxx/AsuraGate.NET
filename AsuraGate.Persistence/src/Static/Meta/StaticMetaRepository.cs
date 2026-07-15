namespace AsuraGate.Persistence.Static.Meta;

public class StaticMetaRepository
{
    private readonly Gw2ApiPersistenceDatabase _database;

    public StaticMetaRepository(Gw2ApiPersistenceDatabase database)
    {
        _database = database;
    }
    
    public async Task<StaticMetaEntity?> GetAsync(string resource) => await _database.Connection.FindAsync<StaticMetaEntity>(resource);
    
    public Task UpsertAsync(StaticMetaEntity entity) => _database.Connection.InsertOrReplaceAsync(entity);
    
    public Task DeleteAsync(string resource) => _database.Connection.DeleteAsync<StaticMetaEntity>(resource);
}