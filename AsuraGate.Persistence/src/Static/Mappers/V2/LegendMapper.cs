using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class LegendMapper
{
    public static LegendEntity ToEntity(Legend model) => new LegendEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static Legend ToModel(LegendEntity entity) => JsonSerializer.Deserialize<Legend>(entity.Data)!;
}
