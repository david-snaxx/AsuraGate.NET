using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Achievements;
using AsuraGate.StaticCache.Mappers.V2.Achievements;

namespace AsuraGate.StaticCache.Repositories.V2.Achievements;

public class AchievementGroupRepository :
    IStaticCacheRepository<AchievementGroup, string>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public AchievementGroupRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<AchievementGroup?> GetAsync(string id)
    {
        var entity = await _database.Connection.FindAsync<AchievementGroupEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var categoryEntities = await _database.Connection.Table<AchievementGroupCategoryEntity>().Where(category => category.AchievementGroupId == id).ToListAsync();
        return AchievementGroupMapper.ToModel(entity, categoryEntities);
    }

    public async Task<IEnumerable<AchievementGroup>> GetManyAsync(IEnumerable<string> ids)
    {
        var idList = ids.ToList();
        var entities = await _database.Connection
            .Table<AchievementGroupEntity>()
            .Where(x => idList.Contains(x.Id))
            .ToListAsync();
        var categoryEntities = await _database.Connection
            .Table<AchievementGroupCategoryEntity>()
            .Where(category => idList.Contains(category.AchievementGroupId))
            .ToListAsync();

        return entities.Select(entity => AchievementGroupMapper.ToModel(entity, categoryEntities.Where(category => category.AchievementGroupId == entity.Id)));
    }

    public async Task<IEnumerable<AchievementGroup>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<AchievementGroupEntity>().ToListAsync();
        var categoryEntities = await _database.Connection.Table<AchievementGroupCategoryEntity>().ToListAsync();

        return entities.Select(entity => AchievementGroupMapper.ToModel(entity, categoryEntities.Where(category => category.AchievementGroupId == entity.Id)));
    }

    public Task UpsertAsync(AchievementGroup group) => UpsertAllAsync([group]);

    public Task UpsertAllAsync(IEnumerable<AchievementGroup> groups) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var group in groups)
        {
            connection.InsertOrReplace(AchievementGroupMapper.ToAchievementGroupEntity(group));
            connection.Table<AchievementGroupCategoryEntity>().Delete(category => category.AchievementGroupId == group.Id);
            connection.InsertAll(AchievementGroupMapper.ToCategoryEntities(group));
        }
    });

    public Task DeleteAsync(string id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<AchievementGroupCategoryEntity>().Delete(category => category.AchievementGroupId == id);
        connection.Delete<AchievementGroupEntity>(id);
    });
}
