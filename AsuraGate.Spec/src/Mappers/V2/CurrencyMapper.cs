using AsuraGate.Spec.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Mappers.V2;

public static class CurrencyMapper
{
    public static CurrencyEntity ToCurrencyEntity(Currency currency) => new CurrencyEntity()
    {
        Id = currency.Id,
        Name = currency.Name,
        Description = currency.Description,
        Icon = currency.Icon,
        Order = currency.Order
    };

    public static Currency ToModel(CurrencyEntity entity) => new Currency()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        Icon = entity.Icon,
        Order = entity.Order
    };
}
