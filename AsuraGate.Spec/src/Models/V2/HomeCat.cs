using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a cat that can be adopted and displayed in a player's home instance.</summary>
public record HomeCat
{
    /// <summary>Unique cat ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Hint describing how to obtain this cat; may be empty for some cats.</summary>
    [JsonPropertyName("hint")]
    public required string Hint { get; init; }
}
