using SQLite;

namespace AsuraGate.Spec.Entities.V2.Characters;

/// <summary>
/// A saved equipment tab for a character; <see cref="Tab"/> (the model's own one-based tab index) is the
/// natural key within a character. Callers must supply <see cref="CharacterName"/>.
/// <c>EquipmentPvp</c> is a fixed 1:1 optional object, flattened onto this row.
/// </summary>
[Table("character_equipment_tabs")]
public class CharacterEquipmentTabEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("is_active")]
    public bool IsActive { get; set; }

    [NotNull]
    [Column("has_equipment_pvp")]
    public bool HasEquipmentPvp { get; set; }

    [Column("pvp_amulet")]
    public int? PvpAmulet { get; set; }

    [Column("pvp_rune")]
    public int? PvpRune { get; set; }

    [NotNull]
    [Column("has_pvp_sigils")]
    public bool HasPvpSigils { get; set; }
}

/// <summary>A PvP sigil slotted in a <see cref="CharacterEquipmentTabEntity"/>.</summary>
[Table("character_equipment_tab_pvp_sigils")]
public class CharacterEquipmentTabPvpSigilEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}

/// <summary>An equipped item within a <see cref="CharacterEquipmentTabEntity"/>. <c>Stats.Attributes</c> is flattened onto this row.</summary>
[Table("character_equipment_tab_items")]
public class CharacterEquipmentTabItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [Column("skin")]
    public int? Skin { get; set; }

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

    [Column("binding")]
    public string? Binding { get; set; }

    [Column("bound_to")]
    public string? BoundTo { get; set; }

    [NotNull]
    [Column("location")]
    public string Location { get; set; } = string.Empty;

    [NotNull]
    [Column("has_dyes")]
    public bool HasDyes { get; set; }
}

/// <summary>An upgrade component slotted in a <see cref="CharacterEquipmentTabItemEntity"/>.</summary>
[Table("character_equipment_tab_item_upgrades")]
public class CharacterEquipmentTabItemUpgradeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("item_order_index")]
    public int ItemOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}

/// <summary>An infusion slotted in a <see cref="CharacterEquipmentTabItemEntity"/>.</summary>
[Table("character_equipment_tab_item_infusions")]
public class CharacterEquipmentTabItemInfusionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("item_order_index")]
    public int ItemOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}

/// <summary>A dye applied to a <see cref="CharacterEquipmentTabItemEntity"/>.</summary>
[Table("character_equipment_tab_item_dyes")]
public class CharacterEquipmentTabItemDyeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("item_order_index")]
    public int ItemOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("dye_id")]
    public int DyeId { get; set; }
}
