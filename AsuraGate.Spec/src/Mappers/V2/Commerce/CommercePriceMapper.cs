using AsuraGate.Spec.Entities.V2.Commerce;
using AsuraGate.Spec.Models.V2.Commerce;

namespace AsuraGate.Spec.Mappers.V2.Commerce;

public static class CommercePriceMapper
{
    public static CommercePriceEntity ToCommercePriceEntity(CommercePrice price) => new CommercePriceEntity()
    {
        Id = price.Id,
        Whitelisted = price.Whitelisted,
        BuysUnitPrice = price.Buys.UnitPrice,
        BuysQuantity = price.Buys.Quantity,
        SellsUnitPrice = price.Sells.UnitPrice,
        SellsQuantity = price.Sells.Quantity
    };

    public static CommercePrice ToModel(CommercePriceEntity entity) => new CommercePrice()
    {
        Id = entity.Id,
        Whitelisted = entity.Whitelisted,
        Buys = new PriceSummary() { UnitPrice = entity.BuysUnitPrice, Quantity = entity.BuysQuantity },
        Sells = new PriceSummary() { UnitPrice = entity.SellsUnitPrice, Quantity = entity.SellsQuantity }
    };
}
