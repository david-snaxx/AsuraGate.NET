using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a single entry in a PvP league season leaderboard.</summary>
public record PvpLeagueLeaderboardEntry
{
    /// <summary>Account display name of the player or guild on this leaderboard.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Leaderboard position of this entry (1-based).</summary>
    [JsonPropertyName("rank")]
    public required int Rank { get; init; }

    /// <summary>Account or guild ID of this entry.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Team name for team-based leaderboards; null for individual leaderboards.</summary>
    [JsonPropertyName("team")]
    public string? Team { get; init; }

    /// <summary>Team ID for team-based leaderboards; null for individual leaderboards.</summary>
    [JsonPropertyName("team_id")]
    public int? TeamId { get; init; }

    /// <summary>Date string indicating when this snapshot was recorded.</summary>
    [JsonPropertyName("date")]
    public required string Date { get; init; }

    /// <summary>Score components for this entry.</summary>
    [JsonPropertyName("scores")]
    public LeaderboardScore[] Scores { get; init; } = [];
}

/// <summary>Represents a single scored component within a <see cref="PvpLeagueLeaderboardEntry"/>.</summary>
public record LeaderboardScore
{
    /// <summary>Scoring method ID; matches a <see cref="PvpLeaderboardScorings"/> ID.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Numeric score value for this component.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}
