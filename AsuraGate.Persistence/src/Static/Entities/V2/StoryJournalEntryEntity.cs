using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("story_journal_entries")]
public class StoryJournalEntryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
