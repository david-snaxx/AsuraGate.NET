using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Wvw;

/// <summary>Represents kill and death statistics for a WvW match broken down by team and map.</summary>
public record WvwMatchWorldStats
{
    /// <summary>Match ID in the format "{tier}-{position}".</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Total deaths per team across all maps.</summary>
    [JsonPropertyName("deaths")]
    public required WvwTeamValues Deaths { get; init; }

    /// <summary>Total kills per team across all maps.</summary>
    [JsonPropertyName("kills")]
    public required WvwTeamValues Kills { get; init; }

    /// <summary>Per-map kill/death breakdown.</summary>
    [JsonPropertyName("maps")]
    public WvwStatsMap[] Maps { get; init; } = [];
}

/// <summary>Represents kill and death stats for a single map within <see cref="WvwMatchWorldStats"/>.</summary>
public record WvwStatsMap
{
    /// <summary>Map ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Map type identifier (e.g., "Center", "RedHome", "BlueHome", "GreenHome").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Deaths per team on this map.</summary>
    [JsonPropertyName("deaths")]
    public required WvwTeamValues Deaths { get; init; }

    /// <summary>Kills per team on this map.</summary>
    [JsonPropertyName("kills")]
    public required WvwTeamValues Kills { get; init; }
}
