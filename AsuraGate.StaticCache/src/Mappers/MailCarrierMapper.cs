using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="MailCarrier"/> to <see cref="MailCarrierEntity"/>.
/// </summary>
public static class MailCarrierMapper
{
    public static MailCarrierEntity ToEntity(MailCarrier mailCarrier) => new MailCarrierEntity()
    {
        Id = mailCarrier.Id,
        Name = mailCarrier.Name,
        Icon = mailCarrier.Icon,
        Order = mailCarrier.Order,
    };

    public static IReadOnlyList<MailCarrierUnlockItemEntity> ToUnlockItemEntities(MailCarrier mailCarrier) =>
        mailCarrier.UnlockItems.Select(itemId => new MailCarrierUnlockItemEntity() { MailCarrierId = mailCarrier.Id, ItemId = itemId }).ToList();

    public static IReadOnlyList<MailCarrierFlagEntity> ToFlagEntities(MailCarrier mailCarrier) =>
        mailCarrier.Flags.Select(flag => new MailCarrierFlagEntity() { MailCarrierId = mailCarrier.Id, Flag = flag }).ToList();

    public static MailCarrier ToModel(MailCarrierEntity entity, IEnumerable<int> unlockItems, IEnumerable<string> flags) => new MailCarrier()
    {
        Id = entity.Id,
        Name = entity.Name,
        Icon = entity.Icon,
        Order = entity.Order,
        UnlockItems = unlockItems.ToArray(),
        Flags = flags.ToArray(),
    };
}
