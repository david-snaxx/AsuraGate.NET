using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities.V2;

namespace AsuraGate.StaticCache.Mappers.V2;

public static class NoveltyMapper
{
    public static NoveltyEntity ToNoveltyEntity(Novelty novelty) => new NoveltyEntity()
    {
        Id = novelty.Id,
        Name = novelty.Name,
        Description = novelty.Description,
        Icon = novelty.Icon,
        Slot = novelty.Slot
    };

    public static IEnumerable<NoveltyUnlockItemEntity> ToUnlockItemEntities(Novelty novelty) =>
        novelty.UnlockItem.Select(itemId => new NoveltyUnlockItemEntity()
        {
            NoveltyId = novelty.Id,
            ItemId = itemId
        });

    public static Novelty ToModel(NoveltyEntity entity, IEnumerable<NoveltyUnlockItemEntity> unlockItemEntities) => new Novelty()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Slot = entity.Slot,
        UnlockItem = unlockItemEntities.Select(item => item.ItemId).ToArray()
    };
}
