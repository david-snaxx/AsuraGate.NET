using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountHomesteadDecorationMapper
{
    public static AccountHomesteadDecorationEntity ToEntity(string accountId, AccountHomesteadDecoration decoration) => new AccountHomesteadDecorationEntity()
    {
        AccountId = accountId,
        DecorationId = decoration.Id,
        Count = decoration.Count
    };

    public static AccountHomesteadDecoration ToModel(AccountHomesteadDecorationEntity entity) => new AccountHomesteadDecoration()
    {
        Id = entity.DecorationId,
        Count = entity.Count
    };
}
