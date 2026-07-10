using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Wvw;

/// <summary>Represents the world and alliance composition overview for a WvW match, showing which worlds are assigned to each team.</summary>
public record WvwMatchWorldOverview
{
    /// <summary>Match ID in the format "{tier}-{position}".</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Primary world ID for each team.</summary>
    [JsonPropertyName("worlds")]
    public required WvwTeamValues Worlds { get; init; }

    /// <summary>All world IDs for each team including linked worlds.</summary>
    [JsonPropertyName("all_worlds")]
    public required WvwMultiTeamValues AllWorlds { get; init; }

    /// <summary>Timestamp when the match began.</summary>
    [JsonPropertyName("start_time")]
    public required DateTime StartTime { get; init; }

    /// <summary>Timestamp when the match ends or ended.</summary>
    [JsonPropertyName("end_time")]
    public required DateTime EndTime { get; init; }
}
