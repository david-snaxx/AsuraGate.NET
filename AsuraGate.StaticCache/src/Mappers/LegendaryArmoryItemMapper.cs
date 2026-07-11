using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="LegendaryArmoryItem"/> to <see cref="LegendaryArmoryItemEntity"/>.
/// </summary>
public static class LegendaryArmoryItemMapper
{
    public static LegendaryArmoryItemEntity ToEntity(LegendaryArmoryItem item) => new LegendaryArmoryItemEntity()
    {
        Id = item.Id,
        MaxCount = item.MaxCount,
    };

    public static LegendaryArmoryItem ToModel(LegendaryArmoryItemEntity entity) => new LegendaryArmoryItem()
    {
        Id = entity.Id,
        MaxCount = entity.MaxCount,
    };
}
