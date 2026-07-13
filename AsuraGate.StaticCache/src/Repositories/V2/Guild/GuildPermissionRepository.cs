using AsuraGate.Spec.Models.V2.Guild;
using AsuraGate.StaticCache.Entities.V2.Guild;
using AsuraGate.StaticCache.Mappers.V2.Guild;

namespace AsuraGate.StaticCache.Repositories.V2.Guild;

public class GuildPermissionRepository :
    IStaticCacheRepository<GuildPermission, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public GuildPermissionRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<GuildPermission?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<GuildPermissionEntity>(id);
        return entity is null ? null : GuildPermissionMapper.ToModel(entity);
    }

    public async Task<IEnumerable<GuildPermission>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<GuildPermissionEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        return entities.Select(GuildPermissionMapper.ToModel);
    }

    public async Task<IEnumerable<GuildPermission>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<GuildPermissionEntity>().ToListAsync();
        return entities.Select(GuildPermissionMapper.ToModel);
    }

    public Task UpsertAsync(GuildPermission permission) => UpsertAllAsync([permission]);

    public Task UpsertAllAsync(IEnumerable<GuildPermission> permissions) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var permission in permissions)
        {
            connection.InsertOrReplace(GuildPermissionMapper.ToGuildPermissionEntity(permission));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.DeleteAsync<GuildPermissionEntity>(id);
}
