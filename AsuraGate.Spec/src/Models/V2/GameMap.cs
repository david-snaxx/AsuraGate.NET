using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a playable map in GW2, including its level range and geographic coordinates.</summary>
public record GameMap
{
    /// <summary>Unique map ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the map.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Minimum recommended character level for this map.</summary>
    [JsonPropertyName("min_level")]
    public required int MinLevel { get; init; }

    /// <summary>Maximum recommended character level for this map.</summary>
    [JsonPropertyName("max_level")]
    public required int MaxLevel { get; init; }

    /// <summary>Default floor shown for this map in the world map.</summary>
    [JsonPropertyName("default_floor")]
    public required int DefaultFloor { get; init; }

    /// <summary>Map type (e.g., "Public", "Instance", "Tutorial", "GuildHall").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>List of floor indices available for this map.</summary>
    [JsonPropertyName("floors")]
    public int[] Floors { get; init; } = [];

    /// <summary>ID of the region containing this map.</summary>
    [JsonPropertyName("region_id")]
    public int? RegionId { get; init; } = null;

    /// <summary>Display name of the region containing this map.</summary>
    [JsonPropertyName("region_name")]
    public string? RegionName { get; init; } = null;

    /// <summary>ID of the continent containing this map; resolvable to a <see cref="Continent"/>.</summary>
    [JsonPropertyName("continent_id")]
    public int? ContinentId { get; init; } = null;

    /// <summary>Display name of the continent containing this map.</summary>
    [JsonPropertyName("continent_name")]
    public string? ContinentName { get; init; } = null;

    /// <summary>Bounds of the map in map-local coordinates [[x1,y1],[x2,y2]].</summary>
    [JsonPropertyName("map_rect")]
    public int[][] MapRect { get; init; } = [];

    /// <summary>Bounds of the map projected into continent coordinates [[x1,y1],[x2,y2]].</summary>
    [JsonPropertyName("continent_rect")]
    public int[][] ContinentRect { get; init; } = [];
}
