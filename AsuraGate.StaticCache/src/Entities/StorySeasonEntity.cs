using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.StorySeason"/>.
/// </summary>
[Table("story_seasons")]
public class StorySeasonEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }
}

/// <summary>Stories belonging to a <see cref="StorySeasonEntity"/>.</summary>
[Table("story_season_stories")]
public class StorySeasonStoryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("story_season_id")]
    public string StorySeasonId { get; set; } = string.Empty; // FK to StorySeasonEntity

    [NotNull, Indexed, Column("story_id")]
    public int StoryId { get; set; } // FK to StoryEntity
}
