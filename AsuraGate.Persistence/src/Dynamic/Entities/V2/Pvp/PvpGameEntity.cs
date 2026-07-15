using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Pvp;

[Table("pvp_games")]
public class PvpGameEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
