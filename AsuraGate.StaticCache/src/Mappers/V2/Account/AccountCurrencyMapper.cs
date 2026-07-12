using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountCurrencyMapper
{
    public static AccountCurrencyEntity ToEntity(string accountId, AccountCurrency currency) => new AccountCurrencyEntity()
    {
        AccountId = accountId,
        CurrencyId = currency.Id,
        Value = currency.Value
    };

    public static AccountCurrency ToModel(AccountCurrencyEntity entity) => new AccountCurrency()
    {
        Id = entity.CurrencyId,
        Value = entity.Value
    };
}
