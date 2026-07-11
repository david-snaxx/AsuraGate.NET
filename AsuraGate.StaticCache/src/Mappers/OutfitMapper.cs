using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Outfit"/> to <see cref="OutfitEntity"/>.
/// </summary>
public static class OutfitMapper
{
    public static OutfitEntity ToEntity(Outfit outfit) => new OutfitEntity()
    {
        Id = outfit.Id,
        Name = outfit.Name,
        Icon = outfit.Icon,
    };

    public static IReadOnlyList<OutfitUnlockItemEntity> ToUnlockItemEntities(Outfit outfit) =>
        outfit.UnlockItems.Select(itemId => new OutfitUnlockItemEntity() { OutfitId = outfit.Id, ItemId = itemId }).ToList();

    public static Outfit ToModel(OutfitEntity entity, IEnumerable<int> unlockItems) => new Outfit()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        UnlockItems = unlockItems.ToArray(),
    };
}
