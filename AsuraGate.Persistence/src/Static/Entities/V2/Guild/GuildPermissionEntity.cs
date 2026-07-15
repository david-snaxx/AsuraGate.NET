using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Guild;

[Table("guild_permissions")]
public class GuildPermissionEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
