using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Mappers.V2.Homestead;

public static class HomesteadDecorationCategoryMapper
{
    public static HomesteadDecorationCategoryEntity ToEntity(HomesteadDecorationCategory model) => new HomesteadDecorationCategoryEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static HomesteadDecorationCategory ToModel(HomesteadDecorationCategoryEntity entity) => JsonSerializer.Deserialize<HomesteadDecorationCategory>(entity.Data)!;
}
