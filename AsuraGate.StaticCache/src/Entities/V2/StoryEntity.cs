using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Story"/>.
/// </summary>
[Table("stories")]
public class StoryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("season")]
    public string Season { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("timeline")]
    public string Timeline { get; set; } = string.Empty;

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [NotNull]
    [Column("order")]
    public int Order { get; set; }
}

/// <summary>Chapter within a <see cref="StoryEntity"/>.</summary>
[Table("story_chapters")]
public class StoryChapterEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("story_id")]
    public int StoryId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>Race a <see cref="StoryEntity"/> is available to.</summary>
[Table("story_races")]
public class StoryRaceEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("story_id")]
    public int StoryId { get; set; }

    [NotNull]
    [Column("race")]
    public string Race { get; set; } = string.Empty;
}

/// <summary>Behavior flag on a <see cref="StoryEntity"/>.</summary>
[Table("story_flags")]
public class StoryFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("story_id")]
    public int StoryId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}
