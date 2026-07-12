using AsuraGate.Spec.Entities.V2.WizardsVault;
using AsuraGate.Spec.Models.V2.WizardsVault;

namespace AsuraGate.Spec.Mappers.V2.WizardsVault;

public static class WizardsVaultObjectiveMapper
{
    public static WizardsVaultObjectiveEntity ToWizardsVaultObjectiveEntity(WizardsVaultObjective objective) => new WizardsVaultObjectiveEntity()
    {
        Id = objective.Id,
        Title = objective.Title,
        Track = objective.Track,
        Acclaim = objective.Acclaim
    };

    public static WizardsVaultObjective ToModel(WizardsVaultObjectiveEntity entity) => new WizardsVaultObjective()
    {
        Id = entity.Id,
        Title = entity.Title,
        Track = entity.Track,
        Acclaim = entity.Acclaim
    };
}
