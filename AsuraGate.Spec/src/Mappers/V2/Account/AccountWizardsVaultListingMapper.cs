using AsuraGate.Spec.Entities.V2.Account;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Spec.Mappers.V2.Account;

public static class AccountWizardsVaultListingMapper
{
    public static AccountWizardsVaultListingEntity ToEntity(string accountId, AccountWizardsVaultListing listing) => new AccountWizardsVaultListingEntity()
    {
        AccountId = accountId,
        ListingId = listing.Id,
        Icon = listing.Icon,
        Name = listing.Name,
        Description = listing.Description,
        Type = listing.Type,
        Cost = listing.Cost,
        Purchased = listing.Purchased,
        LimitOncePerAccount = listing.LimitOncePerAccount
    };

    public static AccountWizardsVaultListing ToModel(AccountWizardsVaultListingEntity entity) => new AccountWizardsVaultListing()
    {
        Id = entity.ListingId,
        Icon = entity.Icon,
        Name = entity.Name,
        Description = entity.Description,
        Type = entity.Type,
        Cost = entity.Cost,
        Purchased = entity.Purchased,
        LimitOncePerAccount = entity.LimitOncePerAccount
    };
}
