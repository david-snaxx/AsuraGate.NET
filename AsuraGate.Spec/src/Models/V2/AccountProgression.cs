using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a named progression counter for the authenticated account.</summary>
public record AccountProgression
{
    /// <summary>Progression identifier string (e.g., "fractal_agony_impede_level", "pvp_winstreaks").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Current value for this progression counter.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}
