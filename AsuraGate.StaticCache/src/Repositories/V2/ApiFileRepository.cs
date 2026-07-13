using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class ApiFileRepository :
    IStaticCacheRepository<ApiFile, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public ApiFileRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<ApiFile?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<ApiFileEntity>(id);
        return entity is null ? null : ApiFileMapper.ToModel(entity);
    }

    public async Task<IEnumerable<ApiFile>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<ApiFileEntity>().ToListAsync();
        return entities.Select(ApiFileMapper.ToModel);
    }

    public Task UpsertAsync(ApiFile apiFile) => UpsertAllAsync([apiFile]);

    public Task UpsertAllAsync(IEnumerable<ApiFile> apiFiles) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var apiFile in apiFiles)
        {
            connection.InsertOrReplace(ApiFileMapper.ToApiFileEntity(apiFile));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<ApiFileEntity>(id);
}
