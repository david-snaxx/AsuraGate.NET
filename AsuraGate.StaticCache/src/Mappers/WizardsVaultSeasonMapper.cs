using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.StaticCache.Entities;

namespace AsuraGate.StaticCache.Mappers;

/// <summary>
/// Maps <see cref="WizardsVaultSeason"/> to <see cref="WizardsVaultSeasonEntity"/>.
/// </summary>
public static class WizardsVaultSeasonMapper
{
    public static WizardsVaultSeasonEntity ToEntity(WizardsVaultSeason season) => new WizardsVaultSeasonEntity()
    {
        Title = season.Title,
        Start = season.Start,
        End = season.End,
    };

    public static IReadOnlyList<WizardsVaultSeasonListingEntity> ToListingEntities(WizardsVaultSeason season) =>
        season.Listings.Select((listingId, index) => new WizardsVaultSeasonListingEntity() { OrderIndex = index, ListingId = listingId }).ToList();

    public static IReadOnlyList<WizardsVaultSeasonObjectiveEntity> ToObjectiveEntities(WizardsVaultSeason season) =>
        season.Objectives.Select((objectiveId, index) => new WizardsVaultSeasonObjectiveEntity() { OrderIndex = index, ObjectiveId = objectiveId }).ToList();

    public static WizardsVaultSeason ToModel(WizardsVaultSeasonEntity entity, IEnumerable<int> listings, IEnumerable<int> objectives) => new WizardsVaultSeason()
    {
        Title = entity.Title,
        Start = entity.Start,
        End = entity.End,
        Listings = listings.ToArray(),
        Objectives = objectives.ToArray(),
    };
}
