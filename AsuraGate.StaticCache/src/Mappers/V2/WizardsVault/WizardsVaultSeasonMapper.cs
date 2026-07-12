using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.StaticCache.Entities.V2.WizardsVault;

namespace AsuraGate.StaticCache.Mappers.V2.WizardsVault;

public static class WizardsVaultSeasonMapper
{
    public static WizardsVaultSeasonEntity ToWizardsVaultSeasonEntity(WizardsVaultSeason season) => new WizardsVaultSeasonEntity()
    {
        Start = season.Start,
        Title = season.Title,
        End = season.End
    };

    public static IEnumerable<WizardsVaultSeasonListingEntity> ToListingEntities(WizardsVaultSeason season) =>
        season.Listings.Select(listingId => new WizardsVaultSeasonListingEntity() { SeasonStart = season.Start, ListingId = listingId });

    public static IEnumerable<WizardsVaultSeasonObjectiveEntity> ToObjectiveEntities(WizardsVaultSeason season) =>
        season.Objectives.Select(objectiveId => new WizardsVaultSeasonObjectiveEntity() { SeasonStart = season.Start, ObjectiveId = objectiveId });

    public static WizardsVaultSeason ToModel(
        WizardsVaultSeasonEntity entity,
        IEnumerable<WizardsVaultSeasonListingEntity> listingEntities,
        IEnumerable<WizardsVaultSeasonObjectiveEntity> objectiveEntities) => new WizardsVaultSeason()
    {
        Title = entity.Title,
        Start = entity.Start,
        End = entity.End,
        Listings = listingEntities.Select(listing => listing.ListingId).ToArray(),
        Objectives = objectiveEntities.Select(objective => objective.ObjectiveId).ToArray()
    };
}
