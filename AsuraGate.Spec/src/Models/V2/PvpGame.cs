using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a single PvP match result recorded for the account.</summary>
public record PvpGame
{
    /// <summary>Unique game ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>ID of the PvP map this game was played on.</summary>
    [JsonPropertyName("map_id")]
    public required int MapId { get; init; }

    /// <summary>Timestamp when the game started.</summary>
    [JsonPropertyName("started")]
    public required DateTime Started { get; init; }

    /// <summary>Timestamp when the game ended.</summary>
    [JsonPropertyName("ended")]
    public required DateTime Ended { get; init; }

    /// <summary>Outcome for this account: "Victory" or "Defeat".</summary>
    [JsonPropertyName("result")]
    public required string Result { get; init; }

    /// <summary>Team color this player was assigned to: "Red" or "Blue".</summary>
    [JsonPropertyName("team")]
    public required string Team { get; init; }

    /// <summary>Profession played during this game (e.g., "Guardian", "Mesmer").</summary>
    [JsonPropertyName("profession")]
    public required string Profession { get; init; }

    /// <summary>Final score breakdown for both teams.</summary>
    [JsonPropertyName("scores")]
    public required PvpGameScores Scores { get; init; }

    /// <summary>Rating type for this match (e.g., "Ranked", "Rated", "None").</summary>
    [JsonPropertyName("rating_type")]
    public required string RatingType { get; init; }

    /// <summary>Rating change applied to the account as a result of this game; null if unrated.</summary>
    [JsonPropertyName("rating_change")]
    public int? RatingChange { get; init; }

    /// <summary>Season ID this game was played in; resolvable to a <see cref="PvpSeason"/>; null if not a season game.</summary>
    [JsonPropertyName("season")]
    public string? Season { get; init; }
}

/// <summary>Represents the final score for both teams in a <see cref="PvpGame"/>.</summary>
public record PvpGameScores
{
    /// <summary>Final score of the red team.</summary>
    [JsonPropertyName("red")]
    public required int Red { get; init; }

    /// <summary>Final score of the blue team.</summary>
    [JsonPropertyName("blue")]
    public required int Blue { get; init; }
}
