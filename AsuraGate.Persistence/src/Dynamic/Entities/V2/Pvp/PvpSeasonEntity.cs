using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Pvp;

[Table("pvp_seasons")]
public class PvpSeasonEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
