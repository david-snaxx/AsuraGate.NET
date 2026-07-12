using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.StaticCache.Entities.V2.Account;

namespace AsuraGate.StaticCache.Mappers.V2.Account;

/// <summary>
/// Maps <see cref="AccountWizardsVaultSpecial"/>. NOTE: despite <see cref="AccountWizardsVaultSpecialObjective"/>
/// existing as its own type (with an extra nullable PeriodicAcclaim field), <c>AccountWizardsVaultSpecial.Objectives</c>
/// is actually typed as <c>List&lt;AccountWizardsVaultDailyObjective&gt;</c> on the model - so
/// <see cref="AccountWizardsVaultSpecialObjective"/> is unreferenced anywhere else in the model graph.
/// This looks like a latent bug/dead type in the source model, not a mapping decision - flagging for
/// awareness rather than silently working around it.
/// </summary>
public static class AccountWizardsVaultSpecialMapper
{
    public static IEnumerable<AccountWizardsVaultObjectiveEntity> ToObjectiveEntities(string accountId, AccountWizardsVaultSpecial special) =>
        special.Objectives.Select((objective, index) => new AccountWizardsVaultObjectiveEntity()
        {
            AccountId = accountId,
            Category = "special",
            OrderIndex = index,
            ObjectiveId = objective.Id,
            Title = objective.Title,
            Track = objective.Track,
            Acclaim = objective.Acclaim,
            ProgressCurrent = objective.ProgressCurrent,
            ProgressComplete = objective.ProgressComplete,
            Claimed = objective.Claimed
        });

    public static AccountWizardsVaultSpecial ToModel(IEnumerable<AccountWizardsVaultObjectiveEntity> objectiveEntities) => new AccountWizardsVaultSpecial()
    {
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

    // AccountWizardsVaultSpecialObjective itself (the orphaned type) mapped in isolation, for completeness,
    // using the same shared table (PeriodicAcclaim is the one column this type actually populates).
    public static AccountWizardsVaultObjectiveEntity ToEntity(string accountId, int orderIndex, AccountWizardsVaultSpecialObjective objective) => new AccountWizardsVaultObjectiveEntity()
    {
        AccountId = accountId,
        Category = "special",
        OrderIndex = orderIndex,
        ObjectiveId = objective.Id,
        Title = objective.Title,
        Track = objective.Track,
        Acclaim = objective.Acclaim,
        ProgressCurrent = objective.ProgressCurrent,
        ProgressComplete = objective.ProgressComplete,
        Claimed = objective.Claimed,
        PeriodicAcclaim = objective.PeriodicAcclaim
    };

    public static AccountWizardsVaultSpecialObjective ToSpecialObjectiveModel(AccountWizardsVaultObjectiveEntity entity) => new AccountWizardsVaultSpecialObjective()
    {
        Id = entity.ObjectiveId,
        Title = entity.Title,
        Track = entity.Track,
        Acclaim = entity.Acclaim,
        ProgressCurrent = entity.ProgressCurrent,
        ProgressComplete = entity.ProgressComplete,
        Claimed = entity.Claimed,
        PeriodicAcclaim = entity.PeriodicAcclaim
    };
}
