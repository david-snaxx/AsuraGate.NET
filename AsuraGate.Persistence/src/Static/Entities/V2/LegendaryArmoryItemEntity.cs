using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("legendary_armory_items")]
public class LegendaryArmoryItemEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
