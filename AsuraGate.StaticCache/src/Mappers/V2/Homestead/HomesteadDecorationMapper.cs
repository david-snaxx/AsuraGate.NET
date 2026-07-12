using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities.V2.Homestead;

namespace AsuraGate.StaticCache.Mappers.V2.Homestead;

public static class HomesteadDecorationMapper
{
    public static HomesteadDecorationEntity ToHomesteadDecorationEntity(HomesteadDecoration decoration) => new HomesteadDecorationEntity()
    {
        Id = decoration.Id,
        Name = decoration.Name,
        Description = decoration.Description,
        MaxCount = decoration.MaxCount,
        Icon = decoration.Icon
    };

    public static IEnumerable<HomesteadDecorationCategoryLinkEntity> ToCategoryEntities(HomesteadDecoration decoration) =>
        decoration.Categories.Select(categoryId => new HomesteadDecorationCategoryLinkEntity() { HomesteadDecorationId = decoration.Id, CategoryId = categoryId });

    public static HomesteadDecoration ToModel(HomesteadDecorationEntity entity, IEnumerable<HomesteadDecorationCategoryLinkEntity> categoryEntities) => new HomesteadDecoration()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        MaxCount = entity.MaxCount,
        Icon = entity.Icon,
        Categories = categoryEntities.Select(category => category.CategoryId).ToArray()
    };
}
