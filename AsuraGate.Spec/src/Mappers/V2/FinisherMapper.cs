using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class FinisherMapper
{
    public static FinisherEntity ToFinisherEntity(Finisher finisher) => new FinisherEntity()
    {
        Id = finisher.Id,
        Name = finisher.Name,
        UnlockDetails = finisher.UnlockDetails,
        Order = finisher.Order,
        Icon = finisher.Icon
    };

    public static IEnumerable<FinisherUnlockItemEntity> ToUnlockItemEntities(Finisher finisher) =>
        finisher.UnlockItems.Select(itemId => new FinisherUnlockItemEntity()
        {
            FinisherId = finisher.Id,
            ItemId = itemId
        });

    public static Finisher ToModel(FinisherEntity entity, IEnumerable<FinisherUnlockItemEntity> unlockItemEntities) => new Finisher()
    {
        Id = entity.Id,
        Name = entity.Name,
        UnlockDetails = entity.UnlockDetails,
        Order = entity.Order,
        Icon = entity.Icon,
        UnlockItems = unlockItemEntities.Select(item => item.ItemId).ToArray()
    };
}
