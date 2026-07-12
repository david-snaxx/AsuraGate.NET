using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities.V2.Achievements;

namespace AsuraGate.StaticCache.Mappers.V2.Achievements;

public static class AchievementCategoryMapper
{
    public static AchievementCategoryEntity ToAchievementCategoryEntity(AchievementCategory category) => new AchievementCategoryEntity()
    {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description,
        Order = category.Order,
        Icon = category.Icon
    };

    private static IEnumerable<AchievementCategoryAchievementEntity> ToAchievementEntities(int categoryId, bool isTomorrow, CategoryAchievement[] achievements) =>
        achievements.Select((achievement, index) => new AchievementCategoryAchievementEntity()
        {
            CategoryId = categoryId,
            IsTomorrow = isTomorrow,
            OrderIndex = index,
            AchievementId = achievement.Id,
            RequiredAccessProduct = achievement.RequiredAccess?.Product,
            RequiredAccessCondition = achievement.RequiredAccess?.Condition,
            HasFlags = achievement.Flags is not null,
            LevelMin = achievement.Level?[0],
            LevelMax = achievement.Level?[1]
        });

    public static IEnumerable<AchievementCategoryAchievementEntity> ToAchievementEntities(AchievementCategory category) =>
        ToAchievementEntities(category.Id, false, category.Achievements).Concat(ToAchievementEntities(category.Id, true, category.Tomorrow));

    private static IEnumerable<AchievementCategoryAchievementFlagEntity> ToFlagEntities(int categoryId, bool isTomorrow, CategoryAchievement[] achievements) =>
        achievements.SelectMany((achievement, index) => (achievement.Flags ?? []).Select(flag => new AchievementCategoryAchievementFlagEntity()
        {
            CategoryId = categoryId,
            IsTomorrow = isTomorrow,
            AchievementOrderIndex = index,
            Flag = flag
        }));

    public static IEnumerable<AchievementCategoryAchievementFlagEntity> ToFlagEntities(AchievementCategory category) =>
        ToFlagEntities(category.Id, false, category.Achievements).Concat(ToFlagEntities(category.Id, true, category.Tomorrow));

    public static AchievementCategory ToModel(
        AchievementCategoryEntity entity,
        IEnumerable<AchievementCategoryAchievementEntity> achievementEntities,
        IEnumerable<AchievementCategoryAchievementFlagEntity> flagEntities)
    {
        var achievements = achievementEntities.ToList();
        var flags = flagEntities.ToList();

        CategoryAchievement[] Build(bool isTomorrow) => achievements
            .Where(achievement => achievement.IsTomorrow == isTomorrow)
            .OrderBy(achievement => achievement.OrderIndex)
            .Select(achievement => new CategoryAchievement()
            {
                Id = achievement.AchievementId,
                RequiredAccess = achievement.RequiredAccessProduct is null
                    ? null
                    : new AchievementAccess() { Product = achievement.RequiredAccessProduct, Condition = achievement.RequiredAccessCondition ?? string.Empty },
                Flags = achievement.HasFlags
                    ? flags.Where(flag => flag.IsTomorrow == isTomorrow && flag.AchievementOrderIndex == achievement.OrderIndex).Select(flag => flag.Flag).ToArray()
                    : null,
                Level = achievement.LevelMin is null ? null : [achievement.LevelMin.Value, achievement.LevelMax!.Value]
            }).ToArray();

        return new AchievementCategory()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Order = entity.Order,
            Icon = entity.Icon,
            Achievements = Build(false),
            Tomorrow = Build(true)
        };
    }
}
