using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the unlock progress in a single mastery track for the authenticated account.</summary>
public record AccountMastery
{
    /// <summary>Mastery track ID; resolvable to a <see cref="Mastery"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Number of mastery levels currently unlocked within this track; 0 indicates the track is accessible but no levels have been spent.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }
}
