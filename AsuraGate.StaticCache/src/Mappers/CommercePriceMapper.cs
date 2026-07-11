using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="CommercePrice"/> to <see cref="CommercePriceEntity"/>.
/// </summary>
public static class CommercePriceMapper
{
    public static CommercePriceEntity ToEntity(CommercePrice price) => new CommercePriceEntity()
    {
        Id = price.Id,
        Whitelisted = price.Whitelisted,
        BuyUnitPrice = price.Buys.UnitPrice,
        BuyQuantity = price.Buys.Quantity,
        SellUnitPrice = price.Sells.UnitPrice,
        SellQuantity = price.Sells.Quantity,
    };

    public static CommercePrice ToModel(CommercePriceEntity entity) => new CommercePrice()
    {
        Id = entity.Id,
        Whitelisted = entity.Whitelisted,
        Buys = new PriceSummary() { UnitPrice = entity.BuyUnitPrice, Quantity = entity.BuyQuantity },
        Sells = new PriceSummary() { UnitPrice = entity.SellUnitPrice, Quantity = entity.SellQuantity },
    };
}
