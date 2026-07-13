using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class OutfitRepository :
    IStaticCacheRepository<Outfit, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public OutfitRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Outfit?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<OutfitEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var unlockItemEntities = await _database.Connection.Table<OutfitUnlockItemEntity>().Where(item => item.OutfitId == id).ToListAsync();
        return OutfitMapper.ToModel(entity, unlockItemEntities);
    }

    public async Task<IEnumerable<Outfit>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<OutfitEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var unlockItemEntities = await _database.Connection
            .Table<OutfitUnlockItemEntity>()
            .Where(item => idList.Contains(item.OutfitId))
            .ToListAsync();

        return entities.Select(entity => OutfitMapper.ToModel(entity, unlockItemEntities.Where(item => item.OutfitId == entity.Id)));
    }

    public async Task<IEnumerable<Outfit>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<OutfitEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<OutfitUnlockItemEntity>().ToListAsync();

        return entities.Select(entity => OutfitMapper.ToModel(entity, unlockItemEntities.Where(item => item.OutfitId == entity.Id)));
    }

    public Task UpsertAsync(Outfit outfit) => UpsertAllAsync([outfit]);

    public Task UpsertAllAsync(IEnumerable<Outfit> outfits) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var outfit in outfits)
        {
            connection.InsertOrReplace(OutfitMapper.ToOutfitEntity(outfit));
            connection.Table<OutfitUnlockItemEntity>().Delete(item => item.OutfitId == outfit.Id);
            connection.InsertAll(OutfitMapper.ToUnlockItemEntities(outfit));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<OutfitUnlockItemEntity>().Delete(item => item.OutfitId == id);
        connection.Delete<OutfitEntity>(id);
    });
}
