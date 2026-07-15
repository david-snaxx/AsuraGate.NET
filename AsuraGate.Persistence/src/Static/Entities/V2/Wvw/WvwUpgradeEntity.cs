using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Wvw;

[Table("wvw_upgrades")]
public class WvwUpgradeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
