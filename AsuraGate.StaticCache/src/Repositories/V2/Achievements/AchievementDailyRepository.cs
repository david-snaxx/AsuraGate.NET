using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Achievements;
using AsuraGate.StaticCache.Mappers.V2.Achievements;

namespace AsuraGate.StaticCache.Repositories.V2.Achievements;

/// <summary>
/// <see cref="AchievementDaily"/> is a singleton (today's dailies, no id of its own), so this
/// repository has no id-based lookups - there is only ever one row.
/// </summary>
public class AchievementDailyRepository
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public AchievementDailyRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<AchievementDaily?> GetAsync()
    {
        var entryEntities = await _database.Connection.Table<AchievementDailyEntryEntity>().ToListAsync();
        return entryEntities.Count == 0 ? null : AchievementDailyMapper.ToModel(entryEntities);
    }

    public Task UpsertAsync(AchievementDaily daily) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.InsertOrReplace(AchievementDailyMapper.ToAchievementDailyEntity(daily));
        connection.DeleteAll<AchievementDailyEntryEntity>();
        connection.InsertAll(AchievementDailyMapper.ToEntryEntities(daily));
    });

    public Task DeleteAsync() => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.DeleteAll<AchievementDailyEntryEntity>();
        connection.DeleteAll<AchievementDailyEntity>();
    });
}
