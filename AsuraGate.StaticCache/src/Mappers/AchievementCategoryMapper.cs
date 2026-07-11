using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="AchievementCategory"/> to <see cref="AchievementCategoryEntity"/>. <see cref="AchievementCategoryAchievementEntity"/>
/// uses a DB-assigned id (not provided by the API), so <see cref="ToFlagEntities"/> takes the already-persisted row id.
/// </summary>
public static class AchievementCategoryMapper
{
    public static AchievementCategoryEntity ToEntity(AchievementCategory category) => new AchievementCategoryEntity()
    {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description,
        Order = category.Order,
        Icon = category.Icon,
    };

    public static IReadOnlyList<AchievementCategoryAchievementEntity> ToAchievementEntities(AchievementCategory category) =>
        category.Achievements.Select((entry, index) => ToAchievementEntity(entry, category.Id, "Current", index))
            .Concat(category.Tomorrow.Select((entry, index) => ToAchievementEntity(entry, category.Id, "Tomorrow", index)))
            .ToList();

    private static AchievementCategoryAchievementEntity ToAchievementEntity(CategoryAchievement entry, int categoryId, string kind, int orderIndex) => new AchievementCategoryAchievementEntity()
    {
        AchievementCategoryId = categoryId,
        Kind = kind,
        OrderIndex = orderIndex,
        AchievementId = entry.Id,
        RequiredAccessProduct = entry.RequiredAccess?.Product,
        RequiredAccessCondition = entry.RequiredAccess?.Condition,
        HasFlags = entry.Flags is not null,
        LevelMin = entry.Level?.ElementAtOrDefault(0),
        LevelMax = entry.Level?.ElementAtOrDefault(1),
    };

    public static IReadOnlyList<AchievementCategoryAchievementFlagEntity> ToFlagEntities(CategoryAchievement entry, int achievementCategoryAchievementId) =>
        (entry.Flags ?? []).Select(flag => new AchievementCategoryAchievementFlagEntity() { AchievementCategoryAchievementId = achievementCategoryAchievementId, Flag = flag }).ToList();

    public static CategoryAchievement ToAchievementModel(AchievementCategoryAchievementEntity entity, IEnumerable<string> flags) => new CategoryAchievement()
    {
        Id = entity.AchievementId,
        RequiredAccess = entity.RequiredAccessProduct is null ? null : new AchievementAccess() { Product = entity.RequiredAccessProduct, Condition = entity.RequiredAccessCondition ?? string.Empty },
        Flags = entity.HasFlags ? flags.ToArray() : null,
        Level = entity.LevelMin is null ? null : [entity.LevelMin.Value, entity.LevelMax ?? 0],
    };

    public static AchievementCategory ToModel(AchievementCategoryEntity entity, IEnumerable<CategoryAchievement> achievements, IEnumerable<CategoryAchievement> tomorrow) => new AchievementCategory()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Order = entity.Order,
        Icon = entity.Icon,
        Achievements = achievements.ToArray(),
        Tomorrow = tomorrow.ToArray(),
    };
}
