using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

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
