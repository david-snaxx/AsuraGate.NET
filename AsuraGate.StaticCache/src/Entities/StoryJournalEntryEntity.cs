using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.StoryJournalEntry"/>.
/// </summary>
[Table("story_journal_entries")]
public class StoryJournalEntryEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("level")]
    public int Level { get; set; }

    [NotNull, Indexed, Column("story_id")]
    public int StoryId { get; set; } // FK to StoryEntity
}

/// <summary>An objective within a <see cref="StoryJournalEntryEntity"/> step.</summary>
[Table("story_journal_entry_goals")]
public class StoryJournalEntryGoalEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("story_journal_entry_id")]
    public int StoryJournalEntryId { get; set; } // FK to StoryJournalEntryEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("active")]
    public string Active { get; set; } = string.Empty;

    [NotNull, Column("complete")]
    public string Complete { get; set; } = string.Empty;
}
