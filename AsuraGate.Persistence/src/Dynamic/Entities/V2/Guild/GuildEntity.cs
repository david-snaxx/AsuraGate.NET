using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Guild;

[Table("guilds")]
public class GuildEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
