using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceDelivery"/>. The model has no id
/// (it's "the authenticated account's delivery box" as a whole); this table holds a single row keyed on a
/// fixed id of 1, refreshed wholesale on every fetch rather than diffed.
/// </summary>
[Table("commerce_delivery")]
public class CommerceDeliveryEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; } = 1;

    [NotNull, Column("coins")]
    public long Coins { get; set; }
}

/// <summary>An item pending collection in the <see cref="CommerceDeliveryEntity"/> box.</summary>
[Table("commerce_delivery_items")]
public class CommerceDeliveryItemEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("count")]
    public int Count { get; set; }
}
