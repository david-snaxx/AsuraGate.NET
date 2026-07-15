using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Guild;

[Table("guild_teams")]
public class GuildTeamEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
