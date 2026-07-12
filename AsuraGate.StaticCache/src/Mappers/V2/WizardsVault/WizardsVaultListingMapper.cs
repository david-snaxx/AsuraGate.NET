using AsuraGate.Spec.Models.V2.WizardsVault;
using AsuraGate.StaticCache.Entities.V2.WizardsVault;

namespace AsuraGate.StaticCache.Mappers.V2.WizardsVault;

public static class WizardsVaultListingMapper
{
    public static WizardsVaultListingEntity ToWizardsVaultListingEntity(WizardsVaultListing listing) => new WizardsVaultListingEntity()
    {
        Id = listing.Id,
        ItemId = listing.ItemId,
        ItemCount = listing.ItemCount,
        Type = listing.Type,
        Cost = listing.Cost
    };

    public static WizardsVaultListing ToModel(WizardsVaultListingEntity entity) => new WizardsVaultListing()
    {
        Id = entity.Id,
        ItemId = entity.ItemId,
        ItemCount = entity.ItemCount,
        Type = entity.Type,
        Cost = entity.Cost
    };
}
