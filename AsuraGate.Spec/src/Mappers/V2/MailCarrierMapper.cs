using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class MailCarrierMapper
{
    public static MailCarrierEntity ToMailCarrierEntity(MailCarrier mailCarrier) => new MailCarrierEntity()
    {
        Id = mailCarrier.Id,
        Name = mailCarrier.Name,
        Icon = mailCarrier.Icon,
        Order = mailCarrier.Order
    };

    public static IEnumerable<MailCarrierUnlockItemEntity> ToUnlockItemEntities(MailCarrier mailCarrier) =>
        mailCarrier.UnlockItems.Select(itemId => new MailCarrierUnlockItemEntity()
        {
            MailCarrierId = mailCarrier.Id,
            ItemId = itemId
        });

    public static IEnumerable<MailCarrierFlagEntity> ToFlagEntities(MailCarrier mailCarrier) =>
        mailCarrier.Flags.Select(flag => new MailCarrierFlagEntity()
        {
            MailCarrierId = mailCarrier.Id,
            Flag = flag
        });

    public static MailCarrier ToModel(
        MailCarrierEntity entity,
        IEnumerable<MailCarrierUnlockItemEntity> unlockItemEntities,
        IEnumerable<MailCarrierFlagEntity> flagEntities) => new MailCarrier()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        Order = entity.Order,
        UnlockItems = unlockItemEntities.Select(item => item.ItemId).ToArray(),
        Flags = flagEntities.Select(flag => flag.Flag).ToArray()
    };
}
