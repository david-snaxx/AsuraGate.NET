using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pvp.PvpLeagueLeaderboardEntry"/>. The API scopes this
/// by season/leaderboard-name/region query parameters not reflected on the model itself, so a repository should
/// scope and refresh a leaderboard's rows wholesale rather than diff them individually.
/// </summary>
[Table("pvp_league_leaderboard_entries")]
public class PvpLeagueLeaderboardEntryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull, Indexed, Column("entry_id")]
    public string EntryId { get; set; } = string.Empty; // api "id" value (account or guild id)

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("rank")]
    public int Rank { get; set; }

    [Column("team")]
    public string? Team { get; set; }

    [Indexed, Column("team_id")]
    public int? TeamId { get; set; }

    [NotNull, Column("date")]
    public string Date { get; set; } = string.Empty;
}

/// <summary>A scored component within a <see cref="PvpLeagueLeaderboardEntryEntity"/>.</summary>
[Table("pvp_league_leaderboard_entry_scores")]
public class PvpLeagueLeaderboardEntryScoreEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("leaderboard_entry_id")]
    public int LeaderboardEntryId { get; set; } // FK to PvpLeagueLeaderboardEntryEntity

    [NotNull, Indexed, Column("scoring_id")]
    public string ScoringId { get; set; } = string.Empty;

    [NotNull, Column("value")]
    public int Value { get; set; }
}
