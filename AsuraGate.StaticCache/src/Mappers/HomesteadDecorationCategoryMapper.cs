using AsuraGate.Spec.Models.V2.Homestead;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="HomesteadDecorationCategory"/> to <see cref="HomesteadDecorationCategoryEntity"/>.
/// </summary>
public static class HomesteadDecorationCategoryMapper
{
    public static HomesteadDecorationCategoryEntity ToEntity(HomesteadDecorationCategory category) => new HomesteadDecorationCategoryEntity()
    {
        Id = category.Id,
        Name = category.Name,
    };

    public static HomesteadDecorationCategory ToModel(HomesteadDecorationCategoryEntity entity) => new HomesteadDecorationCategory()
    {
        Id = entity.Id,
        Name = entity.Name,
    };
}
