using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.WizardsVault.WizardsVaultSeason"/>. The model has no id
/// (it's "the current season" as a whole), so this holds one row keyed on a fixed id of 1, refreshed wholesale
/// whenever the active season changes.
/// </summary>
[Table("wizards_vault_season")]
public class WizardsVaultSeasonEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } = 1;

    [NotNull, Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull, Indexed, Column("start")]
    public DateTime Start { get; set; }

    [NotNull, Column("end")]
    public DateTime End { get; set; }
}

/// <summary>
/// A listing available in the <see cref="WizardsVaultSeasonEntity"/> shop. Stored as <c>int</c> to match
/// <c>WizardsVaultSeason.Listings</c> (an <c>int[]</c>) even though <see cref="WizardsVaultListingEntity.Id"/>
/// is a string in the Spec model — that mismatch exists in the source model, not introduced here.
/// </summary>
[Table("wizards_vault_season_listings")]
public class WizardsVaultSeasonListingEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("listing_id")]
    public int ListingId { get; set; }
}

/// <summary>An objective available during the <see cref="WizardsVaultSeasonEntity"/>.</summary>
[Table("wizards_vault_season_objectives")]
public class WizardsVaultSeasonObjectiveEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("objective_id")]
    public int ObjectiveId { get; set; } // FK to WizardsVaultObjectiveEntity
}
