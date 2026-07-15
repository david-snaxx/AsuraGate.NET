using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Wvw;

[Table("wvw_upgrades")]
public class WvwUpgradeEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
