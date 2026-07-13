using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Achievements;
using AsuraGate.StaticCache.Mappers.V2.Achievements;

namespace AsuraGate.StaticCache.Repositories.V2.Achievements;

public class AchievementRepository :
    IStaticCacheRepository<Achievement, int>
{
    private readonly Gw2ApiStaticCacheDatabase _database;

    public AchievementRepository(Gw2ApiStaticCacheDatabase database)
    {
        _database = database;
    }

    public async Task<Achievement?> GetAsync(int id)
    {
        var entity = await _database.Connection.FindAsync<AchievementEntity>(id);
        if (entity is null)
        {
            return null;
        }

        var flagEntities = await _database.Connection.Table<AchievementFlagEntity>().Where(flag => flag.AchievementId == id).ToListAsync();
        var tierEntities = await _database.Connection.Table<AchievementTierEntity>().Where(tier => tier.AchievementId == id).ToListAsync();
        var prerequisiteEntities = await _database.Connection.Table<AchievementPrerequisiteEntity>().Where(prerequisite => prerequisite.AchievementId == id).ToListAsync();
        var rewardEntities = await _database.Connection.Table<AchievementRewardEntity>().Where(reward => reward.AchievementId == id).ToListAsync();
        var bitEntities = await _database.Connection.Table<AchievementBitEntity>().Where(bit => bit.AchievementId == id).ToListAsync();

        return AchievementMapper.ToModel(entity, flagEntities, tierEntities, prerequisiteEntities, rewardEntities, bitEntities);
    }

    public async Task<IEnumerable<Achievement>> GetAllAsync()
    {
        var entities = await _database.Connection.Table<AchievementEntity>().ToListAsync();
        var flagEntities = await _database.Connection.Table<AchievementFlagEntity>().ToListAsync();
        var tierEntities = await _database.Connection.Table<AchievementTierEntity>().ToListAsync();
        var prerequisiteEntities = await _database.Connection.Table<AchievementPrerequisiteEntity>().ToListAsync();
        var rewardEntities = await _database.Connection.Table<AchievementRewardEntity>().ToListAsync();
        var bitEntities = await _database.Connection.Table<AchievementBitEntity>().ToListAsync();

        return entities.Select(entity => AchievementMapper.ToModel(
            entity,
            flagEntities.Where(flag => flag.AchievementId == entity.Id),
            tierEntities.Where(tier => tier.AchievementId == entity.Id),
            prerequisiteEntities.Where(prerequisite => prerequisite.AchievementId == entity.Id),
            rewardEntities.Where(reward => reward.AchievementId == entity.Id),
            bitEntities.Where(bit => bit.AchievementId == entity.Id)));
    }

    public Task UpsertAsync(Achievement achievement) => UpsertAllAsync([achievement]);

    public Task UpsertAllAsync(IEnumerable<Achievement> achievements) => _database.Connection.RunInTransactionAsync(connection =>
    {
        foreach (var achievement in achievements)
        {
            connection.InsertOrReplace(AchievementMapper.ToAchievementEntity(achievement));

            connection.Table<AchievementFlagEntity>().Delete(flag => flag.AchievementId == achievement.Id);
            connection.InsertAll(AchievementMapper.ToAchievementFlagEntity(achievement));

            connection.Table<AchievementTierEntity>().Delete(tier => tier.AchievementId == achievement.Id);
            connection.InsertAll(AchievementMapper.ToAchievementTierEntity(achievement));

            connection.Table<AchievementPrerequisiteEntity>().Delete(prerequisite => prerequisite.AchievementId == achievement.Id);
            connection.InsertAll(AchievementMapper.ToAchievementPrerequisiteEntity(achievement));

            connection.Table<AchievementRewardEntity>().Delete(reward => reward.AchievementId == achievement.Id);
            connection.InsertAll(AchievementMapper.ToAchievementRewardEntities(achievement));

            connection.Table<AchievementBitEntity>().Delete(bit => bit.AchievementId == achievement.Id);
            connection.InsertAll(AchievementMapper.ToAchievementBitEntities(achievement));
        }
    });

    public Task DeleteAsync(int id) => _database.Connection.RunInTransactionAsync(connection =>
    {
        connection.Table<AchievementFlagEntity>().Delete(flag => flag.AchievementId == id);
        connection.Table<AchievementTierEntity>().Delete(tier => tier.AchievementId == id);
        connection.Table<AchievementPrerequisiteEntity>().Delete(prerequisite => prerequisite.AchievementId == id);
        connection.Table<AchievementRewardEntity>().Delete(reward => reward.AchievementId == id);
        connection.Table<AchievementBitEntity>().Delete(bit => bit.AchievementId == id);
        connection.Delete<AchievementEntity>(id);
    });
}
