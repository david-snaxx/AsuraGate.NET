using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommercePrice"/>.
/// </summary>
[Table("commerce_prices")]
public class CommercePriceEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("whitelisted")]
    public bool Whitelisted { get; set; }

    [NotNull, Column("buy_unit_price")]
    public int BuyUnitPrice { get; set; }

    [NotNull, Column("buy_quantity")]
    public int BuyQuantity { get; set; }

    [NotNull, Column("sell_unit_price")]
    public int SellUnitPrice { get; set; }

    [NotNull, Column("sell_quantity")]
    public int SellQuantity { get; set; }
}
