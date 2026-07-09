using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the score breakdown for a WvW match, including per-skirmish and per-map scores.</summary>
public record WvwMatchWorldScores
{
    /// <summary>Match ID in the format "{tier}-{position}".</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Total PPT scores accumulated by each team.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }

    /// <summary>Current victory point totals per team.</summary>
    [JsonPropertyName("victory_points")]
    public required WvwTeamValues VictoryPoints { get; init; }

    /// <summary>Ordered list of completed skirmish score records.</summary>
    [JsonPropertyName("skirmishes")]
    public WvwSkirmish[] Skirmishes { get; init; } = [];

    /// <summary>Per-map score breakdown.</summary>
    [JsonPropertyName("maps")]
    public WvwScoresMap[] Maps { get; init; } = [];
}

/// <summary>Represents the total score for a single map within <see cref="WvwMatchWorldScores"/>.</summary>
public record WvwScoresMap
{
    /// <summary>Map ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Map type identifier (e.g., "Center", "RedHome", "BlueHome", "GreenHome").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Total points scored by each team on this map.</summary>
    [JsonPropertyName("scores")]
    public required WvwTeamValues Scores { get; init; }
}
