using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Novelty"/> to <see cref="NoveltyEntity"/>.
/// </summary>
public static class NoveltyMapper
{
    public static NoveltyEntity ToEntity(Novelty novelty) => new NoveltyEntity()
    {
        Id = novelty.Id,
        Name = novelty.Name,
        Description = novelty.Description,
        Icon = novelty.Icon,
        Slot = novelty.Slot,
    };

    public static IReadOnlyList<NoveltyUnlockItemEntity> ToUnlockItemEntities(Novelty novelty) =>
        novelty.UnlockItem.Select(itemId => new NoveltyUnlockItemEntity() { NoveltyId = novelty.Id, ItemId = itemId }).ToList();

    public static Novelty ToModel(NoveltyEntity entity, IEnumerable<int> unlockItems) => new Novelty()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Slot = entity.Slot,
        UnlockItem = unlockItems.ToArray(),
    };
}
