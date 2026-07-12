using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountLuckMapper
{
    public static AccountLuckEntity ToEntity(string accountId, AccountLuck luck) => new AccountLuckEntity()
    {
        AccountId = accountId,
        Value = luck.Value
    };

    public static AccountLuck ToModel(AccountLuckEntity entity) => new AccountLuck()
    {
        Id = "luck",
        Value = entity.Value
    };
}
