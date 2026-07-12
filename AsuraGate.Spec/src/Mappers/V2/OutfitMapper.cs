using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class OutfitMapper
{
    public static OutfitEntity ToOutfitEntity(Outfit outfit) => new OutfitEntity()
    {
        Id = outfit.Id,
        Name = outfit.Name,
        Icon = outfit.Icon
    };

    public static IEnumerable<OutfitUnlockItemEntity> ToUnlockItemEntities(Outfit outfit) =>
        outfit.UnlockItems.Select(itemId => new OutfitUnlockItemEntity()
        {
            OutfitId = outfit.Id,
            ItemId = itemId
        });

    public static Outfit ToModel(OutfitEntity entity, IEnumerable<OutfitUnlockItemEntity> unlockItemEntities) => new Outfit()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        UnlockItems = unlockItemEntities.Select(item => item.ItemId).ToArray()
    };
}
