using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a novelty cosmetic (e.g., chairs, musical instruments, held items) usable by characters.</summary>
public record Novelty
{
    /// <summary>Unique novelty ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the novelty.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text description.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the novelty icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Slot category of the novelty (e.g., "Chair", "Music", "HeldItem", "Miscellaneous", "Tonic").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>List of item IDs that can unlock this novelty; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_item")]
    public int[] UnlockItem { get; init; } = [];
}
