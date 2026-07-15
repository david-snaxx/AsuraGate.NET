using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Wvw;

[Table("wvw_ranks")]
public class WvwRankEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
