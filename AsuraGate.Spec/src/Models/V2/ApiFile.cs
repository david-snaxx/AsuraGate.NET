using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a named asset file from the GW2 API, such as an icon or UI element.</summary>
public record ApiFile
{
    /// <summary>Unique file identifier string (e.g., "map_dungeon", "ui_coin").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>URL to the image asset.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }
}
