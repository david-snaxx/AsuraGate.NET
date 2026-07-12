using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Repositories;

public class CacheMetaRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public CacheMetaRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<DateTime?> GetLastFullSyncAsync(string tableName)
    {
        var entity = await _database.Connection.FindAsync<CacheMetaEntity>(tableName);
        return entity?.LastFullSyncAt;
    }

    public Task RecordFullSyncAsync(string tableName, DateTime timestamp) =>
        _database.Connection.InsertOrReplaceAsync(new CacheMetaEntity()
        {
            TableName = tableName,
            LastFullSyncAt = timestamp
        });
}
