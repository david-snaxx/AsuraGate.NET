using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.GameMap"/>.
/// </summary>
[Table("game_maps")]
public class GameMapEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("min_level")]
    public int MinLevel { get; set; }

    [NotNull, Column("max_level")]
    public int MaxLevel { get; set; }

    [NotNull, Column("default_floor")]
    public int DefaultFloor { get; set; }

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [Indexed, Column("region_id")]
    public int? RegionId { get; set; }

    [Column("region_name")]
    public string? RegionName { get; set; }

    [Indexed, Column("continent_id")]
    public int? ContinentId { get; set; } // FK to ContinentEntity

    [Column("continent_name")]
    public string? ContinentName { get; set; }

    [NotNull, Column("map_rect_x1")] public int MapRectX1 { get; set; }
    [NotNull, Column("map_rect_y1")] public int MapRectY1 { get; set; }
    [NotNull, Column("map_rect_x2")] public int MapRectX2 { get; set; }
    [NotNull, Column("map_rect_y2")] public int MapRectY2 { get; set; }

    [NotNull, Column("continent_rect_x1")] public int ContinentRectX1 { get; set; }
    [NotNull, Column("continent_rect_y1")] public int ContinentRectY1 { get; set; }
    [NotNull, Column("continent_rect_x2")] public int ContinentRectX2 { get; set; }
    [NotNull, Column("continent_rect_y2")] public int ContinentRectY2 { get; set; }
}

/// <summary>Floor indices available for a <see cref="GameMapEntity"/>.</summary>
[Table("game_map_floors")]
public class GameMapFloorEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("game_map_id")]
    public int GameMapId { get; set; } // FK to GameMapEntity

    [NotNull, Column("floor")]
    public int Floor { get; set; }
}
