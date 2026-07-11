using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="AchievementGroup"/> to <see cref="AchievementGroupEntity"/>.
/// </summary>
public static class AchievementGroupMapper
{
    public static AchievementGroupEntity ToEntity(AchievementGroup group) => new AchievementGroupEntity()
    {
        Id = group.Id,
        Name = group.Name,
        Description = group.Description,
        Order = group.Order,
    };

    public static IReadOnlyList<AchievementGroupCategoryEntity> ToCategoryEntities(AchievementGroup group) =>
        group.Categories.Select((categoryId, index) => new AchievementGroupCategoryEntity()
        {
            AchievementGroupId = group.Id,
            OrderIndex = index,
            CategoryId = categoryId,
        }).ToList();

    public static AchievementGroup ToModel(AchievementGroupEntity entity, IEnumerable<int> categories) => new AchievementGroup()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Order = entity.Order,
        Categories = categories.ToArray(),
    };
}
