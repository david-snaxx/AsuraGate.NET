using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class TitleMapper
{
    public static TitleEntity ToTitleEntity(Title title) => new TitleEntity()
    {
        Id = title.Id,
        Name = title.Name,
        Achievement = title.Achievement,
        ApRequired = title.ApRequired
    };

    public static IEnumerable<TitleAchievementEntity> ToAchievementEntities(Title title) =>
        title.Achievements.Select(achievementId => new TitleAchievementEntity()
        {
            TitleId = title.Id,
            AchievementId = achievementId
        });

    public static Title ToModel(TitleEntity entity, IEnumerable<TitleAchievementEntity> achievementEntities) => new Title()
    {
        Id = entity.Id,
        Name = entity.Name,
        Achievement = entity.Achievement,
        Achievements = achievementEntities.Select(achievement => achievement.AchievementId).ToArray(),
        ApRequired = entity.ApRequired
    };
}
