using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Commerce;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Commerce.CommerceDelivery"/> - one row per
/// account (account-wide singleton, no Id on the model) - callers must supply <see cref="AccountId"/>.
/// </summary>
[Table("commerce_deliveries")]
public class CommerceDeliveryEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("coins")]
    public long Coins { get; set; }
}

/// <summary>An item pending collection in a <see cref="CommerceDeliveryEntity"/>.</summary>
[Table("commerce_delivery_items")]
public class CommerceDeliveryItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
