using AsuraGate.Spec.Entities.V2.Achievements;
using AsuraGate.Spec.Models.V2.Achievements;

namespace AsuraGate.Spec.Mappers.V2.Achievements;

public static class AchievementGroupMapper
{
    public static AchievementGroupEntity ToAchievementGroupEntity(AchievementGroup group) => new AchievementGroupEntity()
    {
        Id = group.Id,
        Name = group.Name,
        Description = group.Description,
        Order = group.Order
    };

    public static IEnumerable<AchievementGroupCategoryEntity> ToCategoryEntities(AchievementGroup group) =>
        group.Categories.Select((categoryId, index) => new AchievementGroupCategoryEntity()
        {
            AchievementGroupId = group.Id,
            OrderIndex = index,
            CategoryId = categoryId
        });

    public static AchievementGroup ToModel(AchievementGroupEntity entity, IEnumerable<AchievementGroupCategoryEntity> categoryEntities) => new AchievementGroup()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Order = entity.Order,
        Categories = categoryEntities.OrderBy(category => category.OrderIndex).Select(category => category.CategoryId).ToArray()
    };
}
