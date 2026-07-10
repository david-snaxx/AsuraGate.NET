using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Pvp;

/// <summary>Represents a player's standing in a single PvP league season, including current position and personal best.</summary>
public record PvpStanding
{
    /// <summary>The player's current standing within the season.</summary>
    [JsonPropertyName("current")]
    public required PvpStandingCurrent Current { get; init; }

    /// <summary>The best standing the player has achieved during the season.</summary>
    [JsonPropertyName("best")]
    public required PvpStandingBest Best { get; init; }

    /// <summary>Season ID for this standing record; resolvable to a <see cref="PvpSeason"/>.</summary>
    [JsonPropertyName("season_id")]
    public required string SeasonId { get; init; }
}

/// <summary>Represents the current league standing within a <see cref="PvpStanding"/> for the active season.</summary>
public record PvpStandingCurrent
{
    /// <summary>Total points accumulated across all divisions in this season.</summary>
    [JsonPropertyName("total_points")]
    public required int TotalPoints { get; init; }

    /// <summary>Current division index (0-based) within the season's division list.</summary>
    [JsonPropertyName("division")]
    public required int Division { get; init; }

    /// <summary>Current tier index (0-based) within the current division.</summary>
    [JsonPropertyName("tier")]
    public required int Tier { get; init; }

    /// <summary>Pip points accumulated within the current tier.</summary>
    [JsonPropertyName("points")]
    public required int Points { get; init; }

    /// <summary>Number of times the player has looped past the final legendary tier.</summary>
    [JsonPropertyName("repeats")]
    public required int Repeats { get; init; }

    /// <summary>Current numerical rating score.</summary>
    [JsonPropertyName("rating")]
    public required int Rating { get; init; }

    /// <summary>Amount of rating decay that has been applied.</summary>
    [JsonPropertyName("decay")]
    public required int Decay { get; init; }
}

/// <summary>Represents the highest league standing achieved during a <see cref="PvpStanding"/>'s season.</summary>
public record PvpStandingBest
{
    /// <summary>Total points accumulated at the time of the personal best.</summary>
    [JsonPropertyName("total_points")]
    public required int TotalPoints { get; init; }

    /// <summary>Division index (0-based) of the personal best.</summary>
    [JsonPropertyName("division")]
    public required int Division { get; init; }

    /// <summary>Tier index (0-based) within the division at the personal best.</summary>
    [JsonPropertyName("tier")]
    public required int Tier { get; init; }

    /// <summary>Pip points within the tier at the personal best.</summary>
    [JsonPropertyName("points")]
    public required int Points { get; init; }

    /// <summary>Number of legendary repeats at the time of the personal best.</summary>
    [JsonPropertyName("repeats")]
    public required int Repeats { get; init; }
}
