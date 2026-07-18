using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Mappers.V2;

public static class LegendaryArmoryItemMapper
{
    public static LegendaryArmoryItemEntity ToEntity(LegendaryArmoryItem model) => new LegendaryArmoryItemEntity()
    {
        Id = model.Id,
        Data = MapperUtils.SerializeModel(model) ?? string.Empty
    };

    public static LegendaryArmoryItem? ToModel(LegendaryArmoryItemEntity entity) => MapperUtils.DeserializeJson<LegendaryArmoryItem>(entity.Data);
}
