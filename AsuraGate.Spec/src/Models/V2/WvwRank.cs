using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a WvW rank title milestone awarded when a player's WvW rank reaches a threshold.</summary>
public record WvwRank
{
    /// <summary>Unique rank ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display title awarded at this rank milestone (e.g., "Invader", "Champion Invader").</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Minimum WvW rank number required to hold this title.</summary>
    [JsonPropertyName("min_rank")]
    public required int MinRank { get; init; }
}
