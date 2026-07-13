using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class BuildRepository :
    IStaticCacheRepository<Build, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public BuildRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Build?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<BuildEntity>(id);
        return entity is null ? null : BuildMapper.ToModel(entity);
    }

    public async Task<IEnumerable<Build>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<BuildEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(BuildMapper.ToModel);
    }

    public async Task<IEnumerable<Build>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<BuildEntity>().ToListAsync();
        return entities.Select(BuildMapper.ToModel);
    }

    public Task UpsertAsync(Build build) => UpsertAllAsync([build]);

    public Task UpsertAllAsync(IEnumerable<Build> builds) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var build in builds)
        {
            connection.InsertOrReplace(BuildMapper.ToBuildEntity(build));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.DeleteAsync<BuildEntity>(id);
}
