using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Finisher"/> to <see cref="FinisherEntity"/>.
/// </summary>
public static class FinisherMapper
{
    public static FinisherEntity ToEntity(Finisher finisher) => new FinisherEntity()
    {
        Id = finisher.Id,
        Name = finisher.Name,
        UnlockDetails = finisher.UnlockDetails,
        Order = finisher.Order,
        Icon = finisher.Icon,
    };

    public static IReadOnlyList<FinisherUnlockItemEntity> ToUnlockItemEntities(Finisher finisher) =>
        finisher.UnlockItems.Select(itemId => new FinisherUnlockItemEntity() { FinisherId = finisher.Id, ItemId = itemId }).ToList();

    public static Finisher ToModel(FinisherEntity entity, IEnumerable<int> unlockItems) => new Finisher()
    {
        Id = entity.Id,
        Name = entity.Name,
        UnlockDetails = entity.UnlockDetails,
        Order = entity.Order,
        Icon = entity.Icon,
        UnlockItems = unlockItems.ToArray(),
    };
}
