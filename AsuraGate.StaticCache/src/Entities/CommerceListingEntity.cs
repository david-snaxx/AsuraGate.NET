using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceListing"/>.
/// </summary>
[Table("commerce_listings")]
public class CommerceListingEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } // FK to ItemEntity
}

/// <summary>A single price level in the Trading Post order book for a <see cref="CommerceListingEntity"/>.</summary>
[Table("commerce_listing_entries")]
public class CommerceListingEntryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("commerce_listing_id")]
    public int CommerceListingId { get; set; } // FK to CommerceListingEntity

    [NotNull, Indexed, Column("side")]
    public string Side { get; set; } = string.Empty; // "Buy" or "Sell"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("listings")]
    public int Listings { get; set; }

    [NotNull, Column("unit_price")]
    public int UnitPrice { get; set; }

    [NotNull, Column("quantity")]
    public int Quantity { get; set; }
}
