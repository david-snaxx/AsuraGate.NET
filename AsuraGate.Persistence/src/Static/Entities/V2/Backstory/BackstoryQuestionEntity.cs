using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Backstory;

[Table("backstory_questions")]
public class BackstoryQuestionEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
