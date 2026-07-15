using System.Text.Json;
using AsuraGate.Persistence.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Mappers.V2.Homestead;

public static class HomesteadDecorationMapper
{
    public static HomesteadDecorationEntity ToEntity(HomesteadDecoration model) => new HomesteadDecorationEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static HomesteadDecoration ToModel(HomesteadDecorationEntity entity) => JsonSerializer.Deserialize<HomesteadDecoration>(entity.Data)!;
}
