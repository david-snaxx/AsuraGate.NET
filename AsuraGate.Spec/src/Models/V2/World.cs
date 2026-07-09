using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a GW2 game world (server).</summary>
public record World
{
    /// <summary>Unique world ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the world, including region prefix (e.g., "Tarnished Coast [NA]").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Current population level (e.g., "Low", "Medium", "High", "VeryHigh", "Full").</summary>
    [JsonPropertyName("population")]
    public required string Population { get; init; }
}
