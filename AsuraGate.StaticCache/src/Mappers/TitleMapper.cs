using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Title"/> to <see cref="TitleEntity"/>.
/// </summary>
public static class TitleMapper
{
    public static TitleEntity ToEntity(Title title) => new TitleEntity()
    {
        Id = title.Id,
        Name = title.Name,
        Achievement = title.Achievement,
        ApRequired = title.ApRequired,
    };

    public static IReadOnlyList<TitleAchievementEntity> ToAchievementEntities(Title title) =>
        title.Achievements.Select(achievementId => new TitleAchievementEntity() { TitleId = title.Id, AchievementId = achievementId }).ToList();

    public static Title ToModel(TitleEntity entity, IEnumerable<int> achievements) => new Title()
    {
        Id = entity.Id,
        Name = entity.Name,
        Achievement = entity.Achievement,
        Achievements = achievements.ToArray(),
        ApRequired = entity.ApRequired,
    };
}
