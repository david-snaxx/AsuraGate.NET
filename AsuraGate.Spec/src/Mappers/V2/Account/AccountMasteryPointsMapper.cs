using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountMasteryPointsMapper
{
    public static AccountMasteryPointsEntity ToEntity(string accountId, AccountMasteryPoints points) => new AccountMasteryPointsEntity()
    {
        AccountId = accountId
    };

    public static IEnumerable<AccountMasteryPointTotalEntity> ToTotalEntities(string accountId, AccountMasteryPoints points) =>
        points.Totals.Select(total => new AccountMasteryPointTotalEntity()
        {
            AccountId = accountId,
            Region = total.Region,
            Spent = total.Spent,
            Earned = total.Earned
        });

    public static IEnumerable<AccountMasteryPointUnlockedEntity> ToUnlockedEntities(string accountId, AccountMasteryPoints points) =>
        points.Unlocked.Select(unlocked => new AccountMasteryPointUnlockedEntity()
        {
            AccountId = accountId,
            MasteryPointId = unlocked.Id,
            Region = unlocked.Region
        });

    public static AccountMasteryPoints ToModel(
        IEnumerable<AccountMasteryPointTotalEntity> totalEntities,
        IEnumerable<AccountMasteryPointUnlockedEntity> unlockedEntities) => new AccountMasteryPoints()
    {
        Totals = totalEntities.Select(total => new MasteryPointTotal() { Region = total.Region, Spent = total.Spent, Earned = total.Earned }).ToArray(),
        Unlocked = unlockedEntities.Select(unlocked => new MasteryPointUnlocked() { Id = unlocked.MasteryPointId, Region = unlocked.Region }).ToArray()
    };
}
