using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountMasteryMapper
{
    public static AccountMasteryEntity ToEntity(string accountId, AccountMastery mastery) => new AccountMasteryEntity()
    {
        AccountId = accountId,
        MasteryId = mastery.Id,
        Level = mastery.Level
    };

    public static AccountMastery ToModel(AccountMasteryEntity entity) => new AccountMastery()
    {
        Id = entity.MasteryId,
        Level = entity.Level
    };
}
