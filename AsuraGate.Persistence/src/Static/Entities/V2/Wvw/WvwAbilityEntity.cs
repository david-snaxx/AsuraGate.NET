using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Wvw;

[Table("wvw_abilities")]
public class WvwAbilityEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
