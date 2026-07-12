using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>An equipped bag on a character. Callers must supply <see cref="CharacterName"/>.</summary>
[Table("character_inventory_bags")]
public class CharacterInventoryBagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("size")]
    public int Size { get; set; }
}

/// <summary>
/// An item occupying a slot in a <see cref="CharacterInventoryBagEntity"/>. Empty slots (null model
/// entries) simply have no row here, rather than a row with a null item id - the caller reassembles the
/// sparse array using the bag's <see cref="CharacterInventoryBagEntity.Size"/> and each row's
/// <see cref="SlotIndex"/>. <c>Stats.Attributes</c> is flattened onto this row.
/// </summary>
[Table("character_inventory_items")]
public class CharacterInventoryItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("bag_order_index")]
    public int BagOrderIndex { get; set; }

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

    [Column("stats_power")]
    public int? StatsPower { get; set; }

    [Column("stats_precision")]
    public int? StatsPrecision { get; set; }

    [Column("stats_toughness")]
    public int? StatsToughness { get; set; }

    [Column("stats_vitality")]
    public int? StatsVitality { get; set; }

    [Column("stats_condition_damage")]
    public int? StatsConditionDamage { get; set; }

    [Column("stats_condition_duration")]
    public int? StatsConditionDuration { get; set; }

    [Column("stats_healing")]
    public int? StatsHealing { get; set; }

    [Column("stats_boon_duration")]
    public int? StatsBoonDuration { get; set; }

    [Column("stats_agony_resistance")]
    public int? StatsAgonyResistance { get; set; }
}

/// <summary>An infusion slotted in a <see cref="CharacterInventoryItemEntity"/>.</summary>
[Table("character_inventory_item_infusions")]
public class CharacterInventoryItemInfusionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("bag_order_index")]
    public int BagOrderIndex { get; set; }

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

/// <summary>An upgrade component slotted in a <see cref="CharacterInventoryItemEntity"/>.</summary>
[Table("character_inventory_item_upgrades")]
public class CharacterInventoryItemUpgradeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("bag_order_index")]
    public int BagOrderIndex { get; set; }

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

/// <summary>A dye applied to a <see cref="CharacterInventoryItemEntity"/>.</summary>
[Table("character_inventory_item_dyes")]
public class CharacterInventoryItemDyeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("bag_order_index")]
    public int BagOrderIndex { get; set; }

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
