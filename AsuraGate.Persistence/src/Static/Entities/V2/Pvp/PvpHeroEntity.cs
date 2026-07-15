using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Pvp;

[Table("pvp_heroes")]
public class PvpHeroEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
