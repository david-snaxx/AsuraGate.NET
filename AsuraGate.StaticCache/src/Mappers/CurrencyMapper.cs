using AsuraGate.Spec.Models.V2;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="Currency"/> to <see cref="CurrencyEntity"/>.
/// </summary>
public static class CurrencyMapper
{
    public static CurrencyEntity ToEntity(Currency currency) => new CurrencyEntity()
    {
        Id = currency.Id,
        Name = currency.Name,
        Description = currency.Description,
        Icon = currency.Icon,
        Order = currency.Order,
    };

    public static Currency ToModel(CurrencyEntity entity) => new Currency()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Order = entity.Order,
    };
}
