using AsuraGate.Spec.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Spec.Mappers.V2.Homestead;

public static class HomesteadDecorationCategoryMapper
{
    public static HomesteadDecorationCategoryEntity ToHomesteadDecorationCategoryEntity(HomesteadDecorationCategory category) => new HomesteadDecorationCategoryEntity()
    {
        Id = category.Id,
        Name = category.Name
    };

    public static HomesteadDecorationCategory ToModel(HomesteadDecorationCategoryEntity entity) => new HomesteadDecorationCategory()
    {
        Id = entity.Id,
        Name = entity.Name
    };
}
