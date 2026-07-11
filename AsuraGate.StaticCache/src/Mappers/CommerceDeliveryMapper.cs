using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="CommerceDelivery"/> to <see cref="CommerceDeliveryEntity"/>.
/// </summary>
public static class CommerceDeliveryMapper
{
    public static CommerceDeliveryEntity ToEntity(CommerceDelivery delivery) => new CommerceDeliveryEntity()
    {
        Coins = delivery.Coins,
    };

    public static IReadOnlyList<CommerceDeliveryItemEntity> ToItemEntities(CommerceDelivery delivery) =>
        delivery.Items.Select(item => new CommerceDeliveryItemEntity() { ItemId = item.Id, Count = item.Count }).ToList();

    public static DeliveryItem ToItemModel(CommerceDeliveryItemEntity entity) => new DeliveryItem() { Id = entity.ItemId, Count = entity.Count };

    public static CommerceDelivery ToModel(CommerceDeliveryEntity entity, IEnumerable<DeliveryItem> items) => new CommerceDelivery()
    {
        Coins = entity.Coins,
        Items = items.ToArray(),
    };
}
