using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a static WvW objective (camp, tower, keep, castle, etc.) on one of the eternal battlegrounds maps.</summary>
public record WvwObjective
{
    /// <summary>Unique objective ID in the format "{mapId}-{objectiveId}".</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the objective.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Objective type (e.g., "Camp", "Tower", "Keep", "Castle", "Ruins", "Mercenary").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Map sector ID that this objective belongs to.</summary>
    [JsonPropertyName("sector_id")]
    public required int SectorId { get; init; }

    /// <summary>ID of the WvW map containing this objective.</summary>
    [JsonPropertyName("map_id")]
    public required int MapId { get; init; }

    /// <summary>Map type identifier (e.g., "Center", "RedHome", "BlueHome", "GreenHome").</summary>
    [JsonPropertyName("map_type")]
    public required string MapType { get; init; }

    /// <summary>Three-element array [x, y, z] of the objective's position in the game world.</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>Two-element array [x, y] of the map label position for this objective.</summary>
    [JsonPropertyName("label_coord")]
    public double[] LabelCoord { get; init; } = [];

    /// <summary>URL to the map marker icon image for this objective.</summary>
    [JsonPropertyName("marker")]
    public string? Marker { get; init; } = null;

    /// <summary>In-game chat link that can be used to link this objective in chat.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }

    /// <summary>Upgrade progression track ID for this objective; resolvable to a <see cref="WvwUpgrade"/>; null if no upgrade track exists.</summary>
    [JsonPropertyName("upgrade_id")]
    public int? UpgradeId { get; init; }
}
