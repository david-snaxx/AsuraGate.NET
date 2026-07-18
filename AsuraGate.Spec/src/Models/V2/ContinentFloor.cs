using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a single floor of a <see cref="Continent"/>, containing all regions and maps on that floor.</summary>
public record ContinentFloor
{
    /// <summary>Floor index number.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Pixel dimensions of the full floor texture [width, height].</summary>
    [JsonPropertyName("texture_dims")]
    public int[] TextureDims { get; init; } = [];

    /// <summary>Optional viewport bounds that restrict the visible area [[x1,y1],[x2,y2]]; empty if no clamping is applied.</summary>
    [JsonPropertyName("clamped_view")]
    public double[][] ClampedView { get; init; } = [];

    /// <summary>Map of region ID strings to region data; see <see cref="FloorRegion"/>.</summary>
    [JsonPropertyName("regions")]
    public Dictionary<string, FloorRegion> Regions { get; init; } = [];
}

/// <summary>Represents a geographic region within a <see cref="ContinentFloor"/>.</summary>
public record FloorRegion
{
    /// <summary>Unique region ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the region (e.g., "Kryta", "Maguuma Jungle").</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; } = null;

    /// <summary>Continent coordinate where the region label is displayed [x, y].</summary>
    [JsonPropertyName("label_coord")]
    public double[] LabelCoord { get; init; } = [];

    /// <summary>Bounding rectangle for this region in continent coordinates [[x1,y1],[x2,y2]].</summary>
    [JsonPropertyName("continent_rect")]
    public double[][] ContinentRect { get; init; } = [];

    /// <summary>Map of map ID strings to map data; see <see cref="RegionMap"/>.</summary>
    [JsonPropertyName("maps")]
    public Dictionary<string, RegionMap> Maps { get; init; } = [];
}

/// <summary>Represents a single map within a <see cref="FloorRegion"/>.</summary>
public record RegionMap
{
    /// <summary>Unique map ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the map.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Minimum recommended character level.</summary>
    [JsonPropertyName("min_level")]
    public required int MinLevel { get; init; }

    /// <summary>Maximum recommended character level.</summary>
    [JsonPropertyName("max_level")]
    public required int MaxLevel { get; init; }

    /// <summary>Default floor index for this map.</summary>
    [JsonPropertyName("default_floor")]
    public required int DefaultFloor { get; init; }

    /// <summary>Continent coordinate where the map label is displayed [x, y].</summary>
    [JsonPropertyName("label_coord")]
    public double[] LabelCoord { get; init; } = [];

    /// <summary>Bounds of the map in map-local coordinates [[x1,y1],[x2,y2]].</summary>
    [JsonPropertyName("map_rect")]
    public double[][] MapRect { get; init; } = [];

    /// <summary>Bounds of the map in continent coordinates [[x1,y1],[x2,y2]].</summary>
    [JsonPropertyName("continent_rect")]
    public double[][] ContinentRect { get; init; } = [];

    /// <summary>List of god shrine locations (Crystal Desert maps only); see <see cref="GodShrine"/>.</summary>
    [JsonPropertyName("god_shrine")]
    public GodShrine[] GodShrine { get; init; } = [];

    /// <summary>Map of POI ID strings to point of interest data; see <see cref="PointOfInterest"/>.</summary>
    [JsonPropertyName("points_of_interest")]
    public Dictionary<string, PointOfInterest> PointsOfInterest { get; init; } = [];

    /// <summary>Map of task ID strings to renown heart data; see <see cref="RegionTask"/>.</summary>
    [JsonPropertyName("tasks")]
    public Dictionary<string, RegionTask> Tasks { get; init; } = [];

    /// <summary>List of hero challenge locations; see <see cref="SkillChallenge"/>.</summary>
    [JsonPropertyName("skill_challenges")]
    public SkillChallenge[] SkillChallenges { get; init; } = [];

    /// <summary>Map of sector ID strings to map sector data; see <see cref="MapSector"/>.</summary>
    [JsonPropertyName("sectors")]
    public Dictionary<string, MapSector> Sectors { get; init; } = [];

    /// <summary>List of adventure locations; see <see cref="MapAdventure"/>.</summary>
    [JsonPropertyName("adventures")]
    public MapAdventure[] Adventures { get; init; } = [];

    /// <summary>List of mastery point collectible locations; see <see cref="MapMasteryPoint"/>.</summary>
    [JsonPropertyName("mastery_points")]
    public MapMasteryPoint[] MasteryPoints { get; init; } = [];
}

/// <summary>Represents a god shrine location within a <see cref="RegionMap"/> (Crystal Desert maps).</summary>
public record GodShrine
{
    /// <summary>Unique shrine ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the shrine when uncontested.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Display name of the shrine when contested.</summary>
    [JsonPropertyName("name_contested")]
    public required string NameContested { get; init; }

    /// <summary>Continent coordinates of the shrine [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>Associated POI ID; resolvable to a <see cref="PointOfInterest"/>.</summary>
    [JsonPropertyName("poi_id")]
    public required int PoiId { get; init; }

    /// <summary>URL to the shrine icon when uncontested.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>URL to the shrine icon when contested.</summary>
    [JsonPropertyName("icon_contested")]
    public required string IconContested { get; init; }
}

/// <summary>Represents a point of interest (landmark, waypoint, or vista) on a map.</summary>
public record PointOfInterest
{
    /// <summary>Unique POI ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the POI; null for some waypoints.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>POI type: "landmark", "waypoint", or "vista".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Floor index where this POI is located.</summary>
    [JsonPropertyName("floor")]
    public required int Floor { get; init; }

    /// <summary>Continent coordinates of the POI [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>In-game chat link for this POI.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }

    /// <summary>URL to the POI map icon; null for some entry types.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }
}

/// <summary>Represents a renown heart task on a map.</summary>
public record RegionTask
{
    /// <summary>Unique task ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Description of what must be done to complete this heart.</summary>
    [JsonPropertyName("objective")]
    public required string Objective { get; init; }

    /// <summary>Recommended character level for this task.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>Continent coordinates of the heart NPC [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>Polygon boundary of the heart's active area.</summary>
    [JsonPropertyName("bounds")]
    public double[][] Bounds { get; init; } = [];

    /// <summary>In-game chat link for this task.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }
}

/// <summary>Represents a hero challenge (skill point) location on a map.</summary>
public record SkillChallenge
{
    /// <summary>Unique hero challenge identifier; may be a UUID string for newer challenges.</summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; } = null;

    /// <summary>Continent coordinates of the hero challenge [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];
}

/// <summary>Represents a named map sector (sub-area) on a map.</summary>
public record MapSector
{
    /// <summary>Unique sector ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the sector.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; } = null;

    /// <summary>Recommended character level for this sector.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>Continent coordinates of the sector label [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>Polygon boundary defining the sector's area.</summary>
    [JsonPropertyName("bounds")]
    public double[][] Bounds { get; init; } = [];

    /// <summary>In-game chat link for this sector.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }
}

/// <summary>Represents an adventure activity location on a map.</summary>
public record MapAdventure
{
    /// <summary>Unique adventure identifier string (UUID format).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the adventure.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Brief description of the adventure.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Continent coordinates of the adventure entrance [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];
}

/// <summary>Represents a mastery point collectible location on a map.</summary>
public record MapMasteryPoint
{
    /// <summary>Unique mastery point ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Continent coordinates of the mastery point [x, y].</summary>
    [JsonPropertyName("coord")]
    public double[] Coord { get; init; } = [];

    /// <summary>Mastery region this point belongs to (e.g., "Maguuma", "CentralTyria").</summary>
    [JsonPropertyName("region")]
    public required string Region { get; init; }
}
