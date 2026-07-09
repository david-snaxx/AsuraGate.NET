using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents an outfit cosmetic that replaces a character's entire appearance when activated.</summary>
public record Outfit
{
    /// <summary>Unique outfit ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the outfit.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the outfit preview icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>List of item IDs that unlock this outfit; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("unlock_items")]
    public int[] UnlockItems { get; init; } = [];
}
