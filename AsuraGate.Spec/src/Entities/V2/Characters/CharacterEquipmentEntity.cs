using SQLite;

namespace AsuraGate.Spec.Entities.V2.Characters;

/// <summary>
/// An equipped item across all of a character's equipment tabs. Callers must supply
/// <see cref="CharacterName"/>. <c>Stats.Attributes</c> is a fixed 1:1 object, flattened onto this row.
/// </summary>
[Table("character_equipment_items")]
public class CharacterEquipmentItemEntity
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

    [Column("charges")]
    public int? Charges { get; set; }

    [NotNull]
    [Column("has_dyes")]
    public bool HasDyes { get; set; }
}

/// <summary>An infusion slotted in a <see cref="CharacterEquipmentItemEntity"/>.</summary>
[Table("character_equipment_item_infusions")]
public class CharacterEquipmentItemInfusionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

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

/// <summary>An upgrade component slotted in a <see cref="CharacterEquipmentItemEntity"/>.</summary>
[Table("character_equipment_item_upgrades")]
public class CharacterEquipmentItemUpgradeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

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

/// <summary>A dye applied to a <see cref="CharacterEquipmentItemEntity"/>; <see cref="CharacterEquipmentItemEntity.HasDyes"/> tracks null-vs-empty.</summary>
[Table("character_equipment_item_dyes")]
public class CharacterEquipmentItemDyeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

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

/// <summary>A one-based equipment tab index that includes a <see cref="CharacterEquipmentItemEntity"/>.</summary>
[Table("character_equipment_item_tabs")]
public class CharacterEquipmentItemTabEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("item_order_index")]
    public int ItemOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }
}
