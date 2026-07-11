using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WizardsVaultObjective"/> to <see cref="WizardsVaultObjectiveEntity"/>.
/// </summary>
public static class WizardsVaultObjectiveMapper
{
    public static WizardsVaultObjectiveEntity ToEntity(WizardsVaultObjective objective) => new WizardsVaultObjectiveEntity()
    {
        Id = objective.Id,
        Title = objective.Title,
        Track = objective.Track,
        Acclaim = objective.Acclaim,
    };

    public static WizardsVaultObjective ToModel(WizardsVaultObjectiveEntity entity) => new WizardsVaultObjective()
    {
        Id = entity.Id,
        Title = entity.Title,
        Track = entity.Track,
        Acclaim = entity.Acclaim,
    };
}
