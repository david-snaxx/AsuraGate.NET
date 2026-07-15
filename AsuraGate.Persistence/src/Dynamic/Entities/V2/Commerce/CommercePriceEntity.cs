using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Commerce;

[Table("commerce_prices")]
public class CommercePriceEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
