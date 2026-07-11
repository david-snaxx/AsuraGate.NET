using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="AchievementDaily"/> to/from <see cref="AchievementDailyEntryEntity"/> rows.
/// </summary>
public static class AchievementDailyMapper
{
    public static IReadOnlyList<AchievementDailyEntryEntity> ToEntities(AchievementDaily daily) =>
        ToEntities(daily.Pve, "Pve")
            .Concat(ToEntities(daily.Pvp, "Pvp"))
            .Concat(ToEntities(daily.Wvw, "Wvw"))
            .Concat(ToEntities(daily.Fractals, "Fractals"))
            .Concat(ToEntities(daily.Special, "Special"))
            .ToList();

    private static IEnumerable<AchievementDailyEntryEntity> ToEntities(IEnumerable<DailyAchievement> entries, string category) =>
        entries.Select((entry, index) => new AchievementDailyEntryEntity()
        {
            Category = category,
            OrderIndex = index,
            AchievementId = entry.Id,
            LevelMin = entry.Level.Min,
            LevelMax = entry.Level.Max,
            RequiredAccessProduct = entry.RequiredAccess?.Product,
            RequiredAccessCondition = entry.RequiredAccess?.Condition,
        });

    public static DailyAchievement ToModel(AchievementDailyEntryEntity entity) => new DailyAchievement()
    {
        Id = entity.AchievementId,
        Level = new DailyLevelRange() { Min = entity.LevelMin, Max = entity.LevelMax },
        RequiredAccess = entity.RequiredAccessProduct is null ? null : new DailyRequiredAccess() { Product = entity.RequiredAccessProduct, Condition = entity.RequiredAccessCondition ?? string.Empty },
    };

    public static AchievementDaily ToModel(IEnumerable<AchievementDailyEntryEntity> entities)
    {
        var byCategory = entities.OrderBy(e => e.OrderIndex).ToLookup(e => e.Category);
        return new AchievementDaily()
        {
            Pve = byCategory["Pve"].Select(ToModel).ToArray(),
            Pvp = byCategory["Pvp"].Select(ToModel).ToArray(),
            Wvw = byCategory["Wvw"].Select(ToModel).ToArray(),
            Fractals = byCategory["Fractals"].Select(ToModel).ToArray(),
            Special = byCategory["Special"].Select(ToModel).ToArray(),
        };
    }
}
