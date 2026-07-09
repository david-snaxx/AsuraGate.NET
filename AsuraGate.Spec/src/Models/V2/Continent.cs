using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a playable continent in GW2 (e.g., Tyria, Mists).</summary>
public record Continent
{
    /// <summary>Unique continent ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the continent.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Pixel dimensions of the full continent map texture [width, height].</summary>
    [JsonPropertyName("continent_dims")]
    public int[] ContinentDims { get; init; } = [];

    /// <summary>Minimum zoom level supported by the map tile service.</summary>
    [JsonPropertyName("min_zoom")]
    public required int MinZoom { get; init; }

    /// <summary>Maximum zoom level supported by the map tile service.</summary>
    [JsonPropertyName("max_zoom")]
    public required int MaxZoom { get; init; }

    /// <summary>List of floor IDs available on this continent; each resolvable to a <see cref="ContinentFloor"/> via API:2/continents/{id}/floors/{floor}.</summary>
    [JsonPropertyName("floors")]
    public int[] Floors { get; init; } = [];
}
