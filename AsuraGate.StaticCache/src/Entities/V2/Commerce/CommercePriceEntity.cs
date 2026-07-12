using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Commerce;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommercePrice"/>. <c>Buys</c>/<c>Sells</c>
/// are fixed 1:1 <c>PriceSummary</c> objects, flattened onto this row.
/// </summary>
[Table("commerce_prices")]
public class CommercePriceEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("whitelisted")]
    public bool Whitelisted { get; set; }

    [NotNull]
    [Column("buys_unit_price")]
    public int BuysUnitPrice { get; set; }

    [NotNull]
    [Column("buys_quantity")]
    public int BuysQuantity { get; set; }

    [NotNull]
    [Column("sells_unit_price")]
    public int SellsUnitPrice { get; set; }

    [NotNull]
    [Column("sells_quantity")]
    public int SellsQuantity { get; set; }
}
