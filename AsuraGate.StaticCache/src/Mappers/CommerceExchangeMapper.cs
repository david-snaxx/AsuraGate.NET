using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="CommerceExchange"/> to <see cref="CommerceExchangeEntity"/>.
/// </summary>
public static class CommerceExchangeMapper
{
    public static CommerceExchangeEntity ToEntity(CommerceExchange exchange, string direction) => new CommerceExchangeEntity()
    {
        Direction = direction,
        CoinsPerGem = exchange.CoinsPerGem,
        Quantity = exchange.Quantity,
    };

    public static CommerceExchange ToModel(CommerceExchangeEntity entity) => new CommerceExchange()
    {
        CoinsPerGem = entity.CoinsPerGem,
        Quantity = entity.Quantity,
    };
}
