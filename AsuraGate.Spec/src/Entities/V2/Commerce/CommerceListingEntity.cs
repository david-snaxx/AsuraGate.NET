using SQLite;

namespace AsuraGate.Spec.Entities.V2.Commerce;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceListing"/>.
/// </summary>
[Table("commerce_listings")]
public class CommerceListingEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }
}

/// <summary>A single order-book price level for a <see cref="CommerceListingEntity"/>; <see cref="IsBuy"/> distinguishes buys from sells.</summary>
[Table("commerce_listing_entries")]
public class CommerceListingEntryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("commerce_listing_id")]
    public int CommerceListingId { get; set; }

    [NotNull]
    [Column("is_buy")]
    public bool IsBuy { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("listings")]
    public int Listings { get; set; }

    [NotNull]
    [Column("unit_price")]
    public int UnitPrice { get; set; }

    [NotNull]
    [Column("quantity")]
    public int Quantity { get; set; }
}
