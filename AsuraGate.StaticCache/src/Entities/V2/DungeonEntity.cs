using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Dungeon"/>.
/// </summary>
[Table("dungeons")]
public class DungeonEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Path within a <see cref="DungeonEntity"/>.</summary>
[Table("dungeon_paths")]
public class DungeonPathEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("dungeon_id")]
    public string DungeonId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("path_id")]
    public string PathId { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;
}
