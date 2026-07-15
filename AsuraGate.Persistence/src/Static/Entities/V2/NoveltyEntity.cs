using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("novelties")]
public class NoveltyEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
