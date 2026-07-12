using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities.V2.Commerce;

namespace AsuraGate.StaticCache.Mappers.V2.Commerce;

public static class CommerceDeliveryMapper
{
    public static CommerceDeliveryEntity ToEntity(string accountId, CommerceDelivery delivery) => new CommerceDeliveryEntity()
    {
        AccountId = accountId,
        Coins = delivery.Coins
    };

    public static IEnumerable<CommerceDeliveryItemEntity> ToItemEntities(string accountId, CommerceDelivery delivery) =>
        delivery.Items.Select(item => new CommerceDeliveryItemEntity() { AccountId = accountId, ItemId = item.Id, Count = item.Count });

    public static CommerceDelivery ToModel(CommerceDeliveryEntity entity, IEnumerable<CommerceDeliveryItemEntity> itemEntities) => new CommerceDelivery()
    {
        Coins = entity.Coins,
        Items = itemEntities.Select(item => new DeliveryItem() { Id = item.ItemId, Count = item.Count }).ToArray()
    };
}
