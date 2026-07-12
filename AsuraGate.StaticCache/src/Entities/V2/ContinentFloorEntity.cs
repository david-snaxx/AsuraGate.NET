using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.ContinentFloor"/>. This is the deepest model in
/// the project: floor -&gt; regions (dictionary) -&gt; maps (dictionary) -&gt; POIs/tasks/sectors (dictionaries)
/// and shrines/adventures/mastery points (lists). Every level below floor carries its ancestors' natural
/// keys (dictionary keys, not surrogate ids) straight down as plain columns, so a row at any depth can be
/// built and queried without walking back up through generated ids - the same trick used for two-level
/// nesting elsewhere (e.g. Raid), just applied through more levels. Fixed-shape coordinate/rect pairs are
/// flattened into named columns; only genuinely variable-length polygon boundaries get their own child
/// table of points.
/// </summary>
[Table("continent_floors")]
public class ContinentFloorEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("texture_dims_width")]
    public int TextureDimsWidth { get; set; }

    [NotNull]
    [Column("texture_dims_height")]
    public int TextureDimsHeight { get; set; }

    [Column("clamped_view_x1")]
    public double? ClampedViewX1 { get; set; }

    [Column("clamped_view_y1")]
    public double? ClampedViewY1 { get; set; }

    [Column("clamped_view_x2")]
    public double? ClampedViewX2 { get; set; }

    [Column("clamped_view_y2")]
    public double? ClampedViewY2 { get; set; }
}

/// <summary>A region (dictionary entry) within a <see cref="ContinentFloorEntity"/>.</summary>
[Table("continent_floor_regions")]
public class ContinentFloorRegionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("floor_id")]
    public int FloorId { get; set; }

    [NotNull]
    [Indexed]
    [Column("region_key")]
    public string RegionKey { get; set; } = string.Empty;

    [NotNull]
    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [NotNull]
    [Column("label_coord_x")]
    public double LabelCoordX { get; set; }

    [NotNull]
    [Column("label_coord_y")]
    public double LabelCoordY { get; set; }

    [NotNull]
    [Column("continent_rect_x1")]
    public double ContinentRectX1 { get; set; }

    [NotNull]
    [Column("continent_rect_y1")]
    public double ContinentRectY1 { get; set; }

    [NotNull]
    [Column("continent_rect_x2")]
    public double ContinentRectX2 { get; set; }

    [NotNull]
    [Column("continent_rect_y2")]
    public double ContinentRectY2 { get; set; }
}

/// <summary>A map (dictionary entry) within a <see cref="ContinentFloorRegionEntity"/>.</summary>
[Table("continent_floor_maps")]
public class ContinentFloorMapEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("floor_id")]
    public int FloorId { get; set; }

    [NotNull]
    [Indexed]
    [Column("region_key")]
    public string RegionKey { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("map_id")]
    public int MapId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("min_level")]
    public int MinLevel { get; set; }

    [NotNull]
    [Column("max_level")]
    public int MaxLevel { get; set; }

    [NotNull]
    [Column("default_floor")]
    public int DefaultFloor { get; set; }

    [NotNull]
    [Column("label_coord_x")]
    public double LabelCoordX { get; set; }

    [NotNull]
    [Column("label_coord_y")]
    public double LabelCoordY { get; set; }

    [NotNull]
    [Column("map_rect_x1")]
    public double MapRectX1 { get; set; }

    [NotNull]
    [Column("map_rect_y1")]
    public double MapRectY1 { get; set; }

    [NotNull]
    [Column("map_rect_x2")]
    public double MapRectX2 { get; set; }

    [NotNull]
    [Column("map_rect_y2")]
    public double MapRectY2 { get; set; }

    [NotNull]
    [Column("continent_rect_x1")]
    public double ContinentRectX1 { get; set; }

    [NotNull]
    [Column("continent_rect_y1")]
    public double ContinentRectY1 { get; set; }

    [NotNull]
    [Column("continent_rect_x2")]
    public double ContinentRectX2 { get; set; }

    [NotNull]
    [Column("continent_rect_y2")]
    public double ContinentRectY2 { get; set; }
}

/// <summary>A god shrine location within a <see cref="ContinentFloorMapEntity"/> (Crystal Desert maps only).</summary>
[Table("continent_floor_god_shrines")]
public class ContinentFloorGodShrineEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("shrine_id")]
    public int ShrineId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("name_contested")]
    public string NameContested { get; set; } = string.Empty;

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Column("poi_id")]
    public int PoiId { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("icon_contested")]
    public string IconContested { get; set; } = string.Empty;
}

/// <summary>A point of interest (dictionary entry) within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_points_of_interest")]
public class ContinentFloorPointOfInterestEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("poi_key")]
    public string PoiKey { get; set; } = string.Empty;

    [NotNull]
    [Column("poi_id")]
    public int PoiId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Column("floor")]
    public int Floor { get; set; }

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }
}

/// <summary>A renown heart task (dictionary entry) within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_tasks")]
public class ContinentFloorTaskEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("task_key")]
    public string TaskKey { get; set; } = string.Empty;

    [NotNull]
    [Column("task_id")]
    public int TaskId { get; set; }

    [NotNull]
    [Column("objective")]
    public string Objective { get; set; } = string.Empty;

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;
}

/// <summary>One polygon point of a <see cref="ContinentFloorTaskEntity"/>'s active-area boundary.</summary>
[Table("continent_floor_task_bounds_points")]
public class ContinentFloorTaskBoundsPointEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("task_key")]
    public string TaskKey { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("x")]
    public double X { get; set; }

    [NotNull]
    [Column("y")]
    public double Y { get; set; }
}

/// <summary>A hero challenge location within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_skill_challenges")]
public class ContinentFloorSkillChallengeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("challenge_id")]
    public string? ChallengeId { get; set; }

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }
}

/// <summary>A named map sector (dictionary entry) within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_sectors")]
public class ContinentFloorSectorEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("sector_key")]
    public string SectorKey { get; set; } = string.Empty;

    [NotNull]
    [Column("sector_id")]
    public int SectorId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;
}

/// <summary>One polygon point of a <see cref="ContinentFloorSectorEntity"/>'s area boundary.</summary>
[Table("continent_floor_sector_bounds_points")]
public class ContinentFloorSectorBoundsPointEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("sector_key")]
    public string SectorKey { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("x")]
    public double X { get; set; }

    [NotNull]
    [Column("y")]
    public double Y { get; set; }
}

/// <summary>An adventure activity location within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_adventures")]
public class ContinentFloorAdventureEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("adventure_id")]
    public string AdventureId { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }
}

/// <summary>A mastery point collectible location within a <see cref="ContinentFloorMapEntity"/>.</summary>
[Table("continent_floor_mastery_points")]
public class ContinentFloorMasteryPointEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("map_key")]
    public string MapKey { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("mastery_point_id")]
    public int MasteryPointId { get; set; }

    [NotNull]
    [Column("coord_x")]
    public double CoordX { get; set; }

    [NotNull]
    [Column("coord_y")]
    public double CoordY { get; set; }

    [NotNull]
    [Indexed]
    [Column("region")]
    public string Region { get; set; } = string.Empty;
}
