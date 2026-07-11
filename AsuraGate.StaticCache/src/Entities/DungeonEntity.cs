using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Dungeon"/>.
/// </summary>
[Table("dungeons")]
public class DungeonEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>A single path within a <see cref="DungeonEntity"/>.</summary>
[Table("dungeon_paths")]
public class DungeonPathEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_dungeon_paths_dungeon_id_path_id", Order = 1, Unique = true)]
    [Column("dungeon_id")]
    public string DungeonId { get; set; } = string.Empty; // FK to DungeonEntity

    [NotNull]
    [Indexed(Name = "ux_dungeon_paths_dungeon_id_path_id", Order = 2, Unique = true)]
    [Column("path_id")]
    public string PathId { get; set; } = string.Empty; // api "id" value, e.g. "ac_story"

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;
}
