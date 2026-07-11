using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="HomesteadDecoration"/> to <see cref="HomesteadDecorationEntity"/>.
/// </summary>
public static class HomesteadDecorationMapper
{
    public static HomesteadDecorationEntity ToEntity(HomesteadDecoration decoration) => new HomesteadDecorationEntity()
    {
        Id = decoration.Id,
        Name = decoration.Name,
        Description = decoration.Description,
        MaxCount = decoration.MaxCount,
        Icon = decoration.Icon,
    };

    public static IReadOnlyList<HomesteadDecorationCategoryLinkEntity> ToCategoryLinkEntities(HomesteadDecoration decoration) =>
        decoration.Categories.Select(categoryId => new HomesteadDecorationCategoryLinkEntity() { DecorationId = decoration.Id, CategoryId = categoryId }).ToList();

    public static HomesteadDecoration ToModel(HomesteadDecorationEntity entity, IEnumerable<int> categories) => new HomesteadDecoration()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        MaxCount = entity.MaxCount,
        Icon = entity.Icon,
        Categories = categories.ToArray(),
    };
}
