using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountWizardsVaultDailyMapper
{
    public static AccountWizardsVaultDailyEntity ToEntity(string accountId, AccountWizardsVaultDaily daily) => new AccountWizardsVaultDailyEntity()
    {
        AccountId = accountId,
        MetaProgressCurrent = daily.MetaProgressCurrent,
        MetaProgressComplete = daily.MetaProgressComplete,
        MetaRewardItemId = daily.MetaRewardItemId,
        MetaRewardAstral = daily.MetaRewardAstral,
        MetaRewardClaimed = daily.MetaRewardClaimed
    };

    public static IEnumerable<AccountWizardsVaultObjectiveEntity> ToObjectiveEntities(string accountId, AccountWizardsVaultDaily daily) =>
        daily.Objectives.Select((objective, index) => new AccountWizardsVaultObjectiveEntity()
        {
            AccountId = accountId,
            Category = "daily",
            OrderIndex = index,
            ObjectiveId = objective.Id,
            Title = objective.Title,
            Track = objective.Track,
            Acclaim = objective.Acclaim,
            ProgressCurrent = objective.ProgressCurrent,
            ProgressComplete = objective.ProgressComplete,
            Claimed = objective.Claimed
        });

    public static AccountWizardsVaultDaily ToModel(AccountWizardsVaultDailyEntity entity, IEnumerable<AccountWizardsVaultObjectiveEntity> objectiveEntities) => new AccountWizardsVaultDaily()
    {
        MetaProgressCurrent = entity.MetaProgressCurrent,
        MetaProgressComplete = entity.MetaProgressComplete,
        MetaRewardItemId = entity.MetaRewardItemId,
        MetaRewardAstral = entity.MetaRewardAstral,
        MetaRewardClaimed = entity.MetaRewardClaimed,
        Objectives = objectiveEntities.OrderBy(objective => objective.OrderIndex).Select(objective => new AccountWizardsVaultDailyObjective()
        {
            Id = objective.ObjectiveId,
            Title = objective.Title,
            Track = objective.Track,
            Acclaim = objective.Acclaim,
            ProgressCurrent = objective.ProgressCurrent,
            ProgressComplete = objective.ProgressComplete,
            Claimed = objective.Claimed
        }).ToList()
    };
}
