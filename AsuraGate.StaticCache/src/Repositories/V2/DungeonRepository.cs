using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class DungeonRepository :
    IStaticCacheRepository<Dungeon, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public DungeonRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Dungeon?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<DungeonEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var pathEntities = await _database.Connection.Table<DungeonPathEntity>().Where(path => path.DungeonId == id).ToListAsync();
        return DungeonMapper.ToModel(entity, pathEntities);
    }

    public async Task<IEnumerable<Dungeon>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<DungeonEntity>().ToListAsync();
        var pathEntities = await _database.Connection.Table<DungeonPathEntity>().ToListAsync();

        return entities.Select(entity => DungeonMapper.ToModel(entity, pathEntities.Where(path => path.DungeonId == entity.Id)));
    }

    public Task UpsertAsync(Dungeon dungeon) => UpsertAllAsync([dungeon]);

    public Task UpsertAllAsync(IEnumerable<Dungeon> dungeons) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var dungeon in dungeons)
        {
            connection.InsertOrReplace(DungeonMapper.ToDungeonEntity(dungeon));
            connection.Table<DungeonPathEntity>().Delete(path => path.DungeonId == dungeon.Id);
            connection.InsertAll(DungeonMapper.ToPathEntities(dungeon));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<DungeonPathEntity>().Delete(path => path.DungeonId == id);
        connection.Delete<DungeonEntity>(id);
    });
}
