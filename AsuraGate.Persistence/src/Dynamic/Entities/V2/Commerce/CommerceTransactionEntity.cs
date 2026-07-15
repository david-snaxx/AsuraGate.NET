using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Commerce;

[Table("commerce_transactions")]
public class CommerceTransactionEntity
{
    [PrimaryKey]
    [Column("id")]
    public long Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
