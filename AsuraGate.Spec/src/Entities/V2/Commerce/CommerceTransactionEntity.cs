using SQLite;

namespace AsuraGate.Spec.Entities.V2.Commerce;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceTransaction"/>.
/// </summary>
[Table("commerce_transactions")]
public class CommerceTransactionEntity
{
    [PrimaryKey]
    [Column("id")]
    public long Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("price")]
    public int Price { get; set; }

    [NotNull]
    [Column("quantity")]
    public int Quantity { get; set; }

    [NotNull]
    [Column("created")]
    public DateTime Created { get; set; }

    [Column("purchased")]
    public DateTime? Purchased { get; set; }
}
