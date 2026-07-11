using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpStanding"/>. The model has no id of its own
/// besides the season it belongs to, which is a reasonable natural key here (one standing per season per account).
/// </summary>
[Table("pvp_standings")]
public class PvpStandingEntity
{
    [PrimaryKey, Column("season_id")]
    public string SeasonId { get; set; } = string.Empty; // FK to PvpSeasonEntity

    [NotNull, Column("current_total_points")] public int CurrentTotalPoints { get; set; }
    [NotNull, Column("current_division")] public int CurrentDivision { get; set; }
    [NotNull, Column("current_tier")] public int CurrentTier { get; set; }
    [NotNull, Column("current_points")] public int CurrentPoints { get; set; }
    [NotNull, Column("current_repeats")] public int CurrentRepeats { get; set; }
    [NotNull, Column("current_rating")] public int CurrentRating { get; set; }
    [NotNull, Column("current_decay")] public int CurrentDecay { get; set; }

    [NotNull, Column("best_total_points")] public int BestTotalPoints { get; set; }
    [NotNull, Column("best_division")] public int BestDivision { get; set; }
    [NotNull, Column("best_tier")] public int BestTier { get; set; }
    [NotNull, Column("best_points")] public int BestPoints { get; set; }
    [NotNull, Column("best_repeats")] public int BestRepeats { get; set; }
}
