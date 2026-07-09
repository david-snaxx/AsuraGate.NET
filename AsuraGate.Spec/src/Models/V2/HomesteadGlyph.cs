using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a glyph that can be used on gathering tools in a player's homestead.</summary>
public record HomesteadGlyph
{
    /// <summary>Unique glyph identifier string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>ID of the item associated with this glyph; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>Gathering tool slot this glyph applies to (e.g., "Logging", "Mining", "Foraging").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }
}
