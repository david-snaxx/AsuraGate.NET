using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.WizardsVault.WizardsVaultListing"/>.
/// </summary>
[Table("wizards_vault_listings")]
public class WizardsVaultListingEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("item_count")]
    public int ItemCount { get; set; }

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Indexed, Column("cost")]
    public int Cost { get; set; }
}
