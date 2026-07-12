using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class LegendaryArmoryItemMapper
{
    public static LegendaryArmoryItemEntity ToLegendaryArmoryItemEntity(LegendaryArmoryItem item) => new LegendaryArmoryItemEntity()
    {
        Id = item.Id,
        MaxCount = item.MaxCount
    };

    public static LegendaryArmoryItem ToModel(LegendaryArmoryItemEntity entity) => new LegendaryArmoryItem()
    {
        Id = entity.Id,
        MaxCount = entity.MaxCount
    };
}
