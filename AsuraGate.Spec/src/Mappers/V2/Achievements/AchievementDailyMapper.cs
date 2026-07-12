using AsuraGate.Spec.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Spec.Mappers.V2.Achievements;

public static class AchievementDailyMapper
{
    public static AchievementDailyEntity ToAchievementDailyEntity(AchievementDaily daily) => new AchievementDailyEntity();

    private static IEnumerable<AchievementDailyEntryEntity> ToEntryEntities(string mode, DailyAchievement[] achievements) =>
        achievements.Select((achievement, index) => new AchievementDailyEntryEntity()
        {
            Mode = mode,
            OrderIndex = index,
            AchievementId = achievement.Id,
            LevelMin = achievement.Level.Min,
            LevelMax = achievement.Level.Max,
            RequiredAccessProduct = achievement.RequiredAccess?.Product,
            RequiredAccessCondition = achievement.RequiredAccess?.Condition
        });

    public static IEnumerable<AchievementDailyEntryEntity> ToEntryEntities(AchievementDaily daily) =>
        ToEntryEntities("pve", daily.Pve)
            .Concat(ToEntryEntities("pvp", daily.Pvp))
            .Concat(ToEntryEntities("wvw", daily.Wvw))
            .Concat(ToEntryEntities("fractals", daily.Fractals))
            .Concat(ToEntryEntities("special", daily.Special));

    public static AchievementDaily ToModel(IEnumerable<AchievementDailyEntryEntity> entryEntities)
    {
        var entries = entryEntities.ToList();

        DailyAchievement[] Build(string mode) => entries
            .Where(entry => entry.Mode == mode)
            .OrderBy(entry => entry.OrderIndex)
            .Select(entry => new DailyAchievement()
            {
                Id = entry.AchievementId,
                Level = new DailyLevelRange() { Min = entry.LevelMin, Max = entry.LevelMax },
                RequiredAccess = entry.RequiredAccessProduct is null
                    ? null
                    : new DailyRequiredAccess() { Product = entry.RequiredAccessProduct, Condition = entry.RequiredAccessCondition ?? string.Empty }
            }).ToArray();

        return new AchievementDaily()
        {
            Pve = Build("pve"),
            Pvp = Build("pvp"),
            Wvw = Build("wvw"),
            Fractals = Build("fractals"),
            Special = Build("special")
        };
    }
}
