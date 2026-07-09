using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a killstroke finisher cosmetic that plays an animation when downing or defeating an enemy.</summary>
public record Finisher
{
    /// <summary>Unique finisher ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the finisher.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of how this finisher is unlocked.</summary>
    [JsonPropertyName("unlock_details")]
    public required string UnlockDetails { get; init; }

    /// <summary>List of item IDs that can unlock this finisher; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];

    /// <summary>Display order in the finisher UI.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>URL to the finisher icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }
}
