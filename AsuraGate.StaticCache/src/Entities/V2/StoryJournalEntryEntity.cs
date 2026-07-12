using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.StoryJournalEntry"/>.
/// </summary>
[Table("story_journal_entries")]
public class StoryJournalEntryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [NotNull]
    [Indexed]
    [Column("story")]
    public int Story { get; set; }
}

/// <summary>Objective within a <see cref="StoryJournalEntryEntity"/> story step.</summary>
[Table("story_journal_entry_goals")]
public class StoryGoalEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("story_journal_entry_id")]
    public int StoryJournalEntryId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("active")]
    public string Active { get; set; } = string.Empty;

    [NotNull]
    [Column("complete")]
    public string Complete { get; set; } = string.Empty;
}
