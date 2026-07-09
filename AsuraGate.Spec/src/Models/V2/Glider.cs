using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a glider cosmetic skin unlockable in the Wardrobe.</summary>
public record Glider
{
    /// <summary>Unique glider ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the glider.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text description.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the glider icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Display order in the glider panel.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>List of item IDs that unlock this glider; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];

    /// <summary>List of default dye color IDs applied to this glider; each resolvable to a <see cref="Dye"/>.</summary>
    [JsonPropertyName("default_dyes")]
    public int[] DefaultDyes { get; init; } = [];
}
