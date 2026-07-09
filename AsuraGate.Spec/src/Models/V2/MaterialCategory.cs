using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a material storage category that groups crafting materials in the bank.</summary>
public record MaterialCategory
{
    /// <summary>Unique material category ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the category (e.g., "Crafting Materials", "Cooking Materials").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>List of item IDs belonging to this category; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("items")]
    public int[] Items { get; init; } = [];

    /// <summary>Display order within the material storage panel.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }
}
