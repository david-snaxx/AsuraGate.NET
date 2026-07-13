using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class NoveltyRepository :
    IStaticCacheRepository<Novelty, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public NoveltyRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Novelty?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<NoveltyEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var unlockItemEntities = await _database.Connection.Table<NoveltyUnlockItemEntity>().Where(item => item.NoveltyId == id).ToListAsync();
        return NoveltyMapper.ToModel(entity, unlockItemEntities);
    }

    public async Task<IEnumerable<Novelty>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<NoveltyEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var unlockItemEntities = await _database.Connection
            .Table<NoveltyUnlockItemEntity>()
            .Where(item => idList.Contains(item.NoveltyId))
            .ToListAsync();

        return entities.Select(entity => NoveltyMapper.ToModel(entity, unlockItemEntities.Where(item => item.NoveltyId == entity.Id)));
    }

    public async Task<IEnumerable<Novelty>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<NoveltyEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<NoveltyUnlockItemEntity>().ToListAsync();

        return entities.Select(entity => NoveltyMapper.ToModel(entity, unlockItemEntities.Where(item => item.NoveltyId == entity.Id)));
    }

    public Task UpsertAsync(Novelty novelty) => UpsertAllAsync([novelty]);

    public Task UpsertAllAsync(IEnumerable<Novelty> novelties) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var novelty in novelties)
        {
            connection.InsertOrReplace(NoveltyMapper.ToNoveltyEntity(novelty));
            connection.Table<NoveltyUnlockItemEntity>().Delete(item => item.NoveltyId == novelty.Id);
            connection.InsertAll(NoveltyMapper.ToUnlockItemEntities(novelty));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<NoveltyUnlockItemEntity>().Delete(item => item.NoveltyId == id);
        connection.Delete<NoveltyEntity>(id);
    });
}
