using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountProgressionMapper
{
    public static AccountProgressionEntity ToEntity(string accountId, AccountProgression progression) => new AccountProgressionEntity()
    {
        AccountId = accountId,
        ProgressionId = progression.Id,
        Value = progression.Value
    };

    public static AccountProgression ToModel(AccountProgressionEntity entity) => new AccountProgression()
    {
        Id = entity.ProgressionId,
        Value = entity.Value
    };
}
