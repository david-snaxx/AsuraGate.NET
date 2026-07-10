using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Homestead;

/// <summary>Represents a category that groups homestead decorations in the decoration panel.</summary>
public record HomesteadDecorationCategory
{
    /// <summary>Unique category ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the category.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
