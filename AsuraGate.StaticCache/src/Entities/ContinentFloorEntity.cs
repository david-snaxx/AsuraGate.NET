using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.ContinentFloor"/>.
/// </summary>
[Table("continent_floors")]
public class ContinentFloorEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull, Indexed(Name = "ux_continent_floors_continent_id_floor_id", Order = 1, Unique = true), Column("floor_id")]
    public int FloorId { get; set; }

    [NotNull]
    [Indexed(Name = "ux_continent_floors_continent_id_floor_id", Order = 2, Unique = true)]
    [Indexed(Name = "ix_continent_floors_continent_id")]
    [Column("continent_id")]
    public int ContinentId { get; set; } // FK to ContinentEntity, not provided by API
    
    [NotNull, Column("texture_dim_width")]
    public int TextureDimWidth { get; set; }
    
    [NotNull, Column("texture_dim_height")]
    public int TextureDimHeight { get; set; }

    [Column("clamped_view_x1")] public double? ClampedViewX1 { get; set; }
    [Column("clamped_view_y1")] public double? ClampedViewY1 { get; set; }
    [Column("clamped_view_x2")] public double? ClampedViewX2 { get; set; }
    [Column("clamped_view_y2")] public double? ClampedViewY2 { get; set; }
}

[Table("continent_floor_regions")]
public class ContinentFloorRegionEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("continent_floor_id")]
    public int ContinentFloorId { get; set; } // FK to ContinentFloorEntity, not provided by API
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [NotNull, Column("label_coord_x")]
    public double LabelCoordX { get; set; }
    
    [NotNull, Column("label_coord_y")]
    public double LabelCoordY { get; set; }

    [NotNull, Column("continent_rect_x1")] public double ContinentRectX1 { get; set; }
    [NotNull, Column("continent_rect_y1")] public double ContinentRectY1 { get; set; }
    [NotNull, Column("continent_rect_x2")] public double ContinentRectX2 { get; set; }
    [NotNull, Column("continent_rect_y2")] public double ContinentRectY2 { get; set; }
}

[Table("continent_floor_region_maps")]
public class ContinentFloorRegionMapEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_id")]
    public int RegionId { get; set; } // FK to ContinentFloorRegionEntity, not provided by API
    
    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [NotNull, Column("min_level")]
    public int MinLevel { get; set; }
    
    [NotNull, Column("max_level")]
    public int MaxLevel { get; set; }
    
    [NotNull, Column("default_floor")]
    public int DefaultFloor { get; set; }
    
    [NotNull, Column("label_coord_x")]
    public double LabelCoordX { get; set; }
    
    [NotNull, Column("label_coord_y")]
    public double LabelCoordY { get; set; }
    
    [NotNull, Column("map_rect_x1")] public double MapRectX1 { get; set; }
    [NotNull, Column("map_rect_y1")] public double MapRectY1 { get; set; }
    [NotNull, Column("map_rect_x2")] public double MapRectX2 { get; set; }
    [NotNull, Column("map_rect_y2")] public double MapRectY2 { get; set; }
    
    [NotNull, Column("continent_rect_x1")] public double ContinentRectX1 { get; set; }
    [NotNull, Column("continent_rect_y1")] public double ContinentRectY1 { get; set; }
    [NotNull, Column("continent_rect_x2")] public double ContinentRectX2 { get; set; }
    [NotNull, Column("continent_rect_y2")] public double ContinentRectY2 { get; set; }
}

[Table("continent_floor_region_map_god_shrines")]
public class ContinentFloorRegionMapGodShrineEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API
    
    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [NotNull, Column("name_contested")]
    public string NameContested { get; set; } = string.Empty;
    
    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }
    
    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
    
    [NotNull, Column("poi_id")]
    public int PoiId { get; set; } // FK to ContinentFloorRegionMapPointOfInterestEntity
    
    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
    
    [NotNull, Column("icon_contested")]
    public string IconContested { get; set; } = string.Empty;
}

[Table("continent_floor_region_map_points_of_interest")]
public class ContinentFloorRegionMapPointOfInterestEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API

    [Column("name")]
    public string? Name { get; set; } // null for some waypoints

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull, Column("floor")]
    public int Floor { get; set; }

    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull, Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;

    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

[Table("continent_floor_region_map_tasks")]
public class ContinentFloorRegionMapTaskEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API
    
    [NotNull, Column("objective")]
    public string Objective { get; set; } = string.Empty;
    
    [NotNull, Column("level")]
    public int Level { get; set; }
    
    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }
    
    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
    
    [NotNull, Column("bounds_json")] public string BoundsJson { get; set; } = "[]";
    
    [NotNull, Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;
}

[Table("continent_floor_region_map_skill_challenges")]
public class ContinentFloorRegionMapSkillChallengeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API
    
    [Column("skill_challenge_id")]
    public string SkillChallengeId { get; set; } = string.Empty; // api "id" value
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API
    
    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }
    
    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
}

[Table("continent_floor_region_map_sectors")]
public class ContinentFloorRegionMapSectorEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API
    
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [NotNull, Column("level")]
    public int Level { get; set; }
    
    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }
    
    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
    
    [NotNull, Column("bounds_json")] public string BoundsJson { get; set; } = "[]";
    
    [NotNull, Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;
}

[Table("continent_floor_region_map_adventures")]
public class ContinentFloorRegionMapAdventureEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
}

[Table("continent_floor_region_map_mastery_points")]
public class ContinentFloorRegionMapMasteryPointEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }
    
    [NotNull, Indexed, Column("region_map_id")]
    public int RegionMapId { get; set; } // FK to ContinentFloorRegionMapEntity, not provided by API
    
    [NotNull, Column("coord_x")]
    public double CoordX { get; set; }
    
    [NotNull, Column("coord_y")]
    public double CoordY { get; set; }
    
    [NotNull, Column("region")]
    public string Region { get; set; } = string.Empty;
}