using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities.V2.Commerce;

namespace AsuraGate.StaticCache.Mappers.V2.Commerce;

public static class CommerceExchangeMapper
{
    public static CommerceExchangeEntity ToCommerceExchangeEntity(CommerceExchange exchange) => new CommerceExchangeEntity()
    {
        CoinsPerGem = exchange.CoinsPerGem,
        Quantity = exchange.Quantity
    };

    public static CommerceExchange ToModel(CommerceExchangeEntity entity) => new CommerceExchange()
    {
        CoinsPerGem = entity.CoinsPerGem,
        Quantity = entity.Quantity
    };
}
