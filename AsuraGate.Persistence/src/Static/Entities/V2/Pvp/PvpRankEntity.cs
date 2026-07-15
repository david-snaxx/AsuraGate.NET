using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Pvp;

[Table("pvp_ranks")]
public class PvpRankEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
