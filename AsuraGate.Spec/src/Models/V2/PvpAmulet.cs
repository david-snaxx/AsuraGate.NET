using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a PvP amulet, which defines the stat template applied to a player's equipment during PvP matches.</summary>
public record PvpAmulet
{
    /// <summary>Unique amulet ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the amulet.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the amulet's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Map of attribute name to value granted by this amulet (e.g., "Power" → 1200).</summary>
    [JsonPropertyName("attributes")]
    public Dictionary<string, int> Attributes { get; init; } = [];
}
