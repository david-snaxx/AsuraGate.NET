using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountWizardsVaultListing"/>. Callers
/// must supply <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_wizards_vault_listings")]
public class AccountWizardsVaultListingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("listing_id")]
    public int ListingId { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("cost")]
    public int Cost { get; set; }

    [NotNull]
    [Column("purchased")]
    public int Purchased { get; set; }

    [NotNull]
    [Column("limit_once_per_account")]
    public bool LimitOncePerAccount { get; set; }
}
