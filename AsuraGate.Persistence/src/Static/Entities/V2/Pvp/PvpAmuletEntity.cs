using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Pvp;

[Table("pvp_amulets")]
public class PvpAmuletEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
