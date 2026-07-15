using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Wvw;

[Table("wvw_ranks")]
public class WvwRankEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
