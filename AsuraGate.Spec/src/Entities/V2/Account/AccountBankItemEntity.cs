using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountBankItem"/>. Callers must supply
/// <see cref="AccountId"/> - not on the model. <c>Stats</c> and its nested <c>Attributes</c> are both
/// fixed 1:1 objects (the latter optional as a whole), flattened onto this row.
/// </summary>
[Table("account_bank_items")]
public class AccountBankItemEntity
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

    [NotNull]
    [Column("has_dyes")]
    public bool HasDyes { get; set; }

    [Column("binding")]
    public string? Binding { get; set; }

    [Column("bound_to")]
    public string? BoundTo { get; set; }

    [Column("stats_id")]
    public int? StatsId { get; set; }

    [Column("stats_agony_resistance")]
    public double? StatsAgonyResistance { get; set; }

    [Column("stats_boon_duration")]
    public double? StatsBoonDuration { get; set; }

    [Column("stats_condition_damage")]
    public double? StatsConditionDamage { get; set; }

    [Column("stats_condition_duration")]
    public double? StatsConditionDuration { get; set; }

    [Column("stats_crit_damage")]
    public double? StatsCritDamage { get; set; }

    [Column("stats_healing")]
    public double? StatsHealing { get; set; }

    [Column("stats_power")]
    public double? StatsPower { get; set; }

    [Column("stats_precision")]
    public double? StatsPrecision { get; set; }

    [Column("stats_toughness")]
    public double? StatsToughness { get; set; }

    [Column("stats_vitality")]
    public double? StatsVitality { get; set; }
}

/// <summary>A dye color applied to an <see cref="AccountBankItemEntity"/>; <see cref="HasDyes"/> on the parent tracks null-vs-empty.</summary>
[Table("account_bank_item_dyes")]
public class AccountBankItemDyeEntity
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
    [Column("dye_id")]
    public int DyeId { get; set; }
}

/// <summary>An upgrade component slotted in an <see cref="AccountBankItemEntity"/>; <see cref="SlotIndexOnItem"/> matches <see cref="AccountBankItemEntity.UpgradeSlotIndices"/> positionally.</summary>
[Table("account_bank_item_upgrades")]
public class AccountBankItemUpgradeEntity
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

    [NotNull]
    [Column("slot_index_on_item")]
    public int SlotIndexOnItem { get; set; }
}

/// <summary>An infusion slotted in an <see cref="AccountBankItemEntity"/>.</summary>
[Table("account_bank_item_infusions")]
public class AccountBankItemInfusionEntity
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
