using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Guild;

[Table("guild_upgrades")]
public class GuildUpgradeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
