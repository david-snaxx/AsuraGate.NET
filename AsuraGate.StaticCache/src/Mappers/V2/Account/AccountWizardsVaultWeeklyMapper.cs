using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

public static class AccountWizardsVaultWeeklyMapper
{
    public static AccountWizardsVaultWeeklyEntity ToEntity(string accountId, AccountWizardsVaultWeekly weekly) => new AccountWizardsVaultWeeklyEntity()
    {
        AccountId = accountId,
        MetaProgressCurrent = weekly.MetaProgressCurrent,
        MetaProgressComplete = weekly.MetaProgressComplete,
        MetaRewardItemId = weekly.MetaRewardItemId,
        MetaRewardAstral = weekly.MetaRewardAstral,
        MetaRewardClaimed = weekly.MetaRewardClaimed
    };

    public static IEnumerable<AccountWizardsVaultObjectiveEntity> ToObjectiveEntities(string accountId, AccountWizardsVaultWeekly weekly) =>
        weekly.Objectives.Select((objective, index) => new AccountWizardsVaultObjectiveEntity()
        {
            AccountId = accountId,
            Category = "weekly",
            OrderIndex = index,
            ObjectiveId = objective.Id,
            Title = objective.Title,
            Track = objective.Track,
            Acclaim = objective.Acclaim,
            ProgressCurrent = objective.ProgressCurrent,
            ProgressComplete = objective.ProgressComplete,
            Claimed = objective.Claimed
        });

    public static AccountWizardsVaultWeekly ToModel(AccountWizardsVaultWeeklyEntity entity, IEnumerable<AccountWizardsVaultObjectiveEntity> objectiveEntities) => new AccountWizardsVaultWeekly()
    {
        MetaProgressCurrent = entity.MetaProgressCurrent,
        MetaProgressComplete = entity.MetaProgressComplete,
        MetaRewardItemId = entity.MetaRewardItemId,
        MetaRewardAstral = entity.MetaRewardAstral,
        MetaRewardClaimed = entity.MetaRewardClaimed,
        Objectives = objectiveEntities.OrderBy(objective => objective.OrderIndex).Select(objective => new AccountWizardsVaultWeeklyObjective()
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
