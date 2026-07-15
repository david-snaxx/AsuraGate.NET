using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Backstory;

[Table("backstory_answers")]
public class BackstoryAnswerEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
