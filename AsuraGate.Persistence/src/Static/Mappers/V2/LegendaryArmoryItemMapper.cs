using System.Text.Json;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class LegendaryArmoryItemMapper
{
    public static LegendaryArmoryItemEntity ToEntity(LegendaryArmoryItem model) => new LegendaryArmoryItemEntity()
    {
        Id = model.Id,
        Data = JsonSerializer.Serialize(model)
    };

    public static LegendaryArmoryItem ToModel(LegendaryArmoryItemEntity entity) => JsonSerializer.Deserialize<LegendaryArmoryItem>(entity.Data)!;
}
