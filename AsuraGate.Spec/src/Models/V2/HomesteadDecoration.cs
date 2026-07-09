using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a decoration item that can be placed in a player's homestead.</summary>
public record HomesteadDecoration
{
    /// <summary>Unique decoration ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the decoration.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text or placement description.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Maximum number of this decoration that can be placed simultaneously.</summary>
    [JsonPropertyName("max_count")]
    public required int MaxCount { get; init; }

    /// <summary>URL to the decoration icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>List of category IDs this decoration belongs to; each resolvable to a <see cref="HomesteadDecorationCategory"/>.</summary>
    [JsonPropertyName("categories")]
    public int[] Categories { get; init; } = [];
}
