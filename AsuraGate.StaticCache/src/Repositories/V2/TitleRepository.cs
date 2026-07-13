using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;
using AsuraGate.StaticCache.Mappers.V2;

namespace AsuraGate.StaticCache.Repositories.V2;

public class TitleRepository :
    IStaticCacheRepository<Title, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public TitleRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Title?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<TitleEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var achievementEntities = await _database.Connection.Table<TitleAchievementEntity>().Where(achievement => achievement.TitleId == id).ToListAsync();
        return TitleMapper.ToModel(entity, achievementEntities);
    }

    public async Task<IEnumerable<Title>> GetManyAsync(IEnumerable<int> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<TitleEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var achievementEntities = await _database.Connection
            .Table<TitleAchievementEntity>()
            .Where(achievement => idList.Contains(achievement.TitleId))
            .ToListAsync();

        return entities.Select(entity => TitleMapper.ToModel(entity, achievementEntities.Where(achievement => achievement.TitleId == entity.Id)));
    }

    public async Task<IEnumerable<Title>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<TitleEntity>().ToListAsync();
        var achievementEntities = await _database.Connection.Table<TitleAchievementEntity>().ToListAsync();

        return entities.Select(entity => TitleMapper.ToModel(entity, achievementEntities.Where(achievement => achievement.TitleId == entity.Id)));
    }

    public async Task<IEnumerable<int>> GetCachedIdsAsync() =>
        (await _database.Connection.Table<TitleEntity>().ToListAsync()).Select(entity => entity.Id);

    public Task UpsertAsync(Title title) => UpsertAllAsync([title]);

    public Task UpsertAllAsync(IEnumerable<Title> titles) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var title in titles)
        {
            connection.InsertOrReplace(TitleMapper.ToTitleEntity(title));
            connection.Table<TitleAchievementEntity>().Delete(achievement => achievement.TitleId == title.Id);
            connection.InsertAll(TitleMapper.ToAchievementEntities(title));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<TitleAchievementEntity>().Delete(achievement => achievement.TitleId == id);
        connection.Delete<TitleEntity>(id);
    });
}
