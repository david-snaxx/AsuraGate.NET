using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Achievements;
using AsuraGate.StaticCache.Mappers.V2.Achievements;

namespace AsuraGate.StaticCache.Repositories.V2.Achievements;

public class AchievementCategoryRepository :
    IStaticCacheRepository<AchievementCategory, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public AchievementCategoryRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<AchievementCategory?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<AchievementCategoryEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var achievementEntities = await _database.Connection.Table<AchievementCategoryAchievementEntity>().Where(achievement => achievement.CategoryId == id).ToListAsync();
        var flagEntities = await _database.Connection.Table<AchievementCategoryAchievementFlagEntity>().Where(flag => flag.CategoryId == id).ToListAsync();
        return AchievementCategoryMapper.ToModel(entity, achievementEntities, flagEntities);
    }

    public async Task<IEnumerable<AchievementCategory>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<AchievementCategoryEntity>().ToListAsync();
        var achievementEntities = await _database.Connection.Table<AchievementCategoryAchievementEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<AchievementCategoryAchievementFlagEntity>().ToListAsync();

        return entities.Select(entity => AchievementCategoryMapper.ToModel(
            entity,
            achievementEntities.Where(achievement => achievement.CategoryId == entity.Id),
            flagEntities.Where(flag => flag.CategoryId == entity.Id)));
    }

    public Task UpsertAsync(AchievementCategory category) => UpsertAllAsync([category]);

    public Task UpsertAllAsync(IEnumerable<AchievementCategory> categories) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var category in categories)
        {
            connection.InsertOrReplace(AchievementCategoryMapper.ToAchievementCategoryEntity(category));
            connection.Table<AchievementCategoryAchievementEntity>().Delete(achievement => achievement.CategoryId == category.Id);
            connection.InsertAll(AchievementCategoryMapper.ToAchievementEntities(category));
            connection.Table<AchievementCategoryAchievementFlagEntity>().Delete(flag => flag.CategoryId == category.Id);
            connection.InsertAll(AchievementCategoryMapper.ToFlagEntities(category));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<AchievementCategoryAchievementEntity>().Delete(achievement => achievement.CategoryId == id);
        connection.Table<AchievementCategoryAchievementFlagEntity>().Delete(flag => flag.CategoryId == id);
        connection.Delete<AchievementCategoryEntity>(id);
    });
}
