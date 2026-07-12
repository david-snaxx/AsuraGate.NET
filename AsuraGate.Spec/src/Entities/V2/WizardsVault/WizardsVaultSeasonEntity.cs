using SQLite;

namespace AsuraGate.Spec.Entities.V2.WizardsVault;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.WizardsVault.WizardsVaultSeason"/>. The model has
/// no natural ID, so <see cref="Start"/> is used as the primary key - seasons can't overlap.
/// </summary>
[Table("wizards_vault_seasons")]
public class WizardsVaultSeasonEntity
{
    [PrimaryKey]
    [Column("start")]
    public DateTime Start { get; set; }

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Column("end")]
    public DateTime End { get; set; }
}

/// <summary>Listing ID active in a <see cref="WizardsVaultSeasonEntity"/>.</summary>
[Table("wizards_vault_season_listings")]
public class WizardsVaultSeasonListingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_start")]
    public DateTime SeasonStart { get; set; }

    [NotNull]
    [Column("listing_id")]
    public int ListingId { get; set; }
}

/// <summary>Objective ID active in a <see cref="WizardsVaultSeasonEntity"/>.</summary>
[Table("wizards_vault_season_objectives")]
public class WizardsVaultSeasonObjectiveEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_start")]
    public DateTime SeasonStart { get; set; }

    [NotNull]
    [Column("objective_id")]
    public int ObjectiveId { get; set; }
}
