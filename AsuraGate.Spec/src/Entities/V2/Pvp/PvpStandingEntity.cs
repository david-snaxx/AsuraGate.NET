using SQLite;

namespace AsuraGate.Spec.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpStanding"/>. This is account-scoped data
/// (one standing per season per account) with no account identifier on the model itself - callers must
/// supply <see cref="AccountId"/>. <c>Current</c> and <c>Best</c> are both fixed 1:1 objects, flattened
/// onto this row.
/// </summary>
[Table("pvp_standings")]
public class PvpStandingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Column("current_total_points")]
    public int CurrentTotalPoints { get; set; }

    [NotNull]
    [Column("current_division")]
    public int CurrentDivision { get; set; }

    [NotNull]
    [Column("current_tier")]
    public int CurrentTier { get; set; }

    [NotNull]
    [Column("current_points")]
    public int CurrentPoints { get; set; }

    [NotNull]
    [Column("current_repeats")]
    public int CurrentRepeats { get; set; }

    [NotNull]
    [Column("current_rating")]
    public int CurrentRating { get; set; }

    [NotNull]
    [Column("current_decay")]
    public int CurrentDecay { get; set; }

    [NotNull]
    [Column("best_total_points")]
    public int BestTotalPoints { get; set; }

    [NotNull]
    [Column("best_division")]
    public int BestDivision { get; set; }

    [NotNull]
    [Column("best_tier")]
    public int BestTier { get; set; }

    [NotNull]
    [Column("best_points")]
    public int BestPoints { get; set; }

    [NotNull]
    [Column("best_repeats")]
    public int BestRepeats { get; set; }
}
