using SQLite;

namespace AsuraGate.Spec.Entities.V2.Pvp;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpLeagueLeaderboardEntry"/>. Like the
/// Guild/* log/member tables, the model doesn't carry which season/board it came from - callers must
/// supply <see cref="SeasonId"/> and <see cref="Board"/> when persisting.
/// </summary>
[Table("pvp_league_leaderboard_entries")]
public class PvpLeagueLeaderboardEntryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("board")]
    public string Board { get; set; } = string.Empty; // "ladder", "guild", "legendary"

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("rank")]
    public int Rank { get; set; }

    [NotNull]
    [Column("entry_id")]
    public string EntryId { get; set; } = string.Empty;

    [Column("team")]
    public string? Team { get; set; }

    [Column("team_id")]
    public int? TeamId { get; set; }

    [NotNull]
    [Column("date")]
    public string Date { get; set; } = string.Empty;
}

/// <summary>
/// A scored component within a <see cref="PvpLeagueLeaderboardEntryEntity"/>. Carries (SeasonId, Board,
/// EntryId) down directly rather than the parent row's surrogate id, consistent with the rest of the
/// project - (season, board, account/guild id) is already a unique combination.
/// </summary>
[Table("pvp_league_leaderboard_entry_scores")]
public class PvpLeagueLeaderboardScoreEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season_id")]
    public string SeasonId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("board")]
    public string Board { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("entry_id")]
    public string EntryId { get; set; } = string.Empty;

    [NotNull]
    [Column("scoring_id")]
    public string ScoringId { get; set; } = string.Empty;

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
