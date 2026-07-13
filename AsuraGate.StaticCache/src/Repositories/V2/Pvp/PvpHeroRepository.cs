using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.StaticCache.Entities.V2.Pvp;
using AsuraGate.StaticCache.Mappers.V2.Pvp;

namespace AsuraGate.StaticCache.Repositories.V2.Pvp;

public class PvpHeroRepository :
    IStaticCacheRepository<PvpHero, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public PvpHeroRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<PvpHero?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<PvpHeroEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var skinEntities = await _database.Connection.Table<PvpHeroSkinEntity>().Where(skin => skin.PvpHeroId == id).ToListAsync();
        var skinIds = skinEntities.Select(skin => skin.Id).ToList();
        var unlockItemEntities = await _database.Connection.Table<PvpHeroSkinUnlockItemEntity>().Where(item => skinIds.Contains(item.PvpHeroSkinId)).ToListAsync();
        return PvpHeroMapper.ToModel(entity, skinEntities, unlockItemEntities);
    }

    public async Task<IEnumerable<PvpHero>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<PvpHeroEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var skinEntities = await _database.Connection
            .Table<PvpHeroSkinEntity>()
            .Where(skin => idList.Contains(skin.PvpHeroId))
            .ToListAsync();
        var skinIds = skinEntities
            .Select(skin => skin.Id)
            .ToList();
        var unlockItemEntities = await _database.Connection
            .Table<PvpHeroSkinUnlockItemEntity>()
            .Where(item => skinIds.Contains(item.PvpHeroSkinId))
            .ToListAsync();

        return entities.Select(entity =>
        {
            var skinsForHero = skinEntities.Where(skin => skin.PvpHeroId == entity.Id).ToList();
            var batchSkinIds = skinsForHero.Select(skin => skin.Id).ToHashSet();
            return PvpHeroMapper.ToModel(entity, skinsForHero, unlockItemEntities.Where(item => batchSkinIds.Contains(item.PvpHeroSkinId)));
        });
    }

    public async Task<IEnumerable<PvpHero>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<PvpHeroEntity>().ToListAsync();
        var skinEntities = await _database.Connection.Table<PvpHeroSkinEntity>().ToListAsync();
        var unlockItemEntities = await _database.Connection.Table<PvpHeroSkinUnlockItemEntity>().ToListAsync();

        return entities.Select(entity =>
        {
            var skinsForHero = skinEntities.Where(skin => skin.PvpHeroId == entity.Id).ToList();
            var skinIds = skinsForHero.Select(skin => skin.Id).ToHashSet();
            return PvpHeroMapper.ToModel(entity, skinsForHero, unlockItemEntities.Where(item => skinIds.Contains(item.PvpHeroSkinId)));
        });
    }

    public async Task<IEnumerable<string>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<PvpHeroEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(PvpHero hero) => UpsertAllAsync([hero]);

    public Task UpsertAllAsync(IEnumerable<PvpHero> heroes) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var hero in heroes)
        {
            var oldSkinIds = connection.Table<PvpHeroSkinEntity>().Where(skin => skin.PvpHeroId == hero.Id).ToList().Select(skin => skin.Id).ToList();
            connection.Table<PvpHeroSkinUnlockItemEntity>().Delete(item => oldSkinIds.Contains(item.PvpHeroSkinId));
            connection.Table<PvpHeroSkinEntity>().Delete(skin => skin.PvpHeroId == hero.Id);

            connection.InsertOrReplace(PvpHeroMapper.ToPvpHeroEntity(hero));
            connection.InsertAll(PvpHeroMapper.ToSkinEntities(hero));
            connection.InsertAll(PvpHeroMapper.ToUnlockItemEntities(hero));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        var skinIds = connection.Table<PvpHeroSkinEntity>().Where(skin => skin.PvpHeroId == id).ToList().Select(skin => skin.Id).ToList();
        connection.Table<PvpHeroSkinUnlockItemEntity>().Delete(item => skinIds.Contains(item.PvpHeroSkinId));
        connection.Table<PvpHeroSkinEntity>().Delete(skin => skin.PvpHeroId == id);
        connection.Delete<PvpHeroEntity>(id);
    });
}
