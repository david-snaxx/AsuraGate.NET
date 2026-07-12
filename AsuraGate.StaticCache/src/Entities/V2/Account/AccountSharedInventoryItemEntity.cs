using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountSharedInventoryItem"/>. Callers
/// must supply <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_shared_inventory_items")]
public class AccountSharedInventoryItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("slot_index")]
    public int SlotIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }

    [Column("charges")]
    public int? Charges { get; set; }

    [Column("skin")]
    public int? Skin { get; set; }

    [Column("binding")]
    public string? Binding { get; set; }
}

/// <summary>An upgrade component slotted in an <see cref="AccountSharedInventoryItemEntity"/>.</summary>
[Table("account_shared_inventory_item_upgrades")]
public class AccountSharedInventoryItemUpgradeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("slot_index")]
    public int SlotIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}

/// <summary>An infusion slotted in an <see cref="AccountSharedInventoryItemEntity"/>.</summary>
[Table("account_shared_inventory_item_infusions")]
public class AccountSharedInventoryItemInfusionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("slot_index")]
    public int SlotIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
