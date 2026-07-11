using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Item"/>.
/// </summary>
[Table("items")]
public class ItemEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty; // also selects the ItemDetailsEntity subtype

    [NotNull, Indexed, Column("rarity")]
    public string Rarity { get; set; } = string.Empty;

    [NotNull, Indexed, Column("level")]
    public int Level { get; set; }

    [NotNull, Column("vendor_value")]
    public int VendorValue { get; set; }

    [Indexed, Column("default_skin")]
    public int? DefaultSkin { get; set; } // FK to SkinEntity

    [NotNull, Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }
}

/// <summary>Behavior flags on an <see cref="ItemEntity"/> (e.g. "Soulbound", "AccountBound").</summary>
[Table("item_flags")]
public class ItemFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Game modes an <see cref="ItemEntity"/> can be used in (e.g. "Pve", "Pvp", "Wvw").</summary>
[Table("item_game_types")]
public class ItemGameTypeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("game_type")]
    public string GameType { get; set; } = string.Empty;
}

/// <summary>Race/profession restrictions on an <see cref="ItemEntity"/>.</summary>
[Table("item_restrictions")]
public class ItemRestrictionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("restriction")]
    public string Restriction { get; set; } = string.Empty;
}

/// <summary>An upgrade path linking an <see cref="ItemEntity"/> to another item, in either direction.</summary>
[Table("item_upgrade_paths")]
public class ItemUpgradePathEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity (the item this path is attached to)

    [NotNull, Indexed, Column("direction")]
    public string Direction { get; set; } = string.Empty; // "Into" or "From"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("upgrade")]
    public string Upgrade { get; set; } = string.Empty;

    [NotNull, Indexed, Column("other_item_id")]
    public int OtherItemId { get; set; } // FK to ItemEntity
}

/// <summary>
/// Type-specific details for an <see cref="ItemEntity"/>. One row per item; only the columns relevant to the
/// owning <see cref="ItemEntity.Type"/> (which selects the <c>ItemDetails</c> subtype) are populated.
/// </summary>
[Table("item_details")]
public class ItemDetailsEntity
{
    [PrimaryKey, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    // Armor slot / Consumable subtype / Container subtype / Gathering subtype / Gizmo subtype /
    // Salvage kit subtype / Trinket subtype / Upgrade component subtype / Weapon type.
    [Indexed, Column("sub_type")]
    public string? SubType { get; set; }

    // Armor only
    [Column("weight_class")]
    public string? WeightClass { get; set; }

    // Armor, Weapon
    [Column("defense")]
    public int? Defense { get; set; }

    // Armor, Back, Trinket, Weapon
    [Column("attribute_adjustment")]
    public double? AttributeAdjustment { get; set; }

    // Armor, Back, Trinket, Weapon
    [Indexed, Column("suffix_item_id")]
    public int? SuffixItemId { get; set; } // FK to ItemEntity

    [Column("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; set; }

    // Bag only
    [Column("bag_size")]
    public int? BagSize { get; set; }

    [Column("no_sell_or_sort")]
    public bool? NoSellOrSort { get; set; }

    // Consumable only
    [Column("consumable_description")]
    public string? ConsumableDescription { get; set; }

    [Column("duration_ms")]
    public int? DurationMs { get; set; }

    [Indexed, Column("unlock_type")]
    public string? UnlockType { get; set; }

    [Indexed, Column("color_id")]
    public int? ColorId { get; set; } // FK to DyeEntity

    [Indexed, Column("recipe_id")]
    public int? RecipeId { get; set; } // FK to RecipeEntity

    [Column("apply_count")]
    public int? ApplyCount { get; set; }

    [Column("unlock_name")]
    public string? UnlockName { get; set; }

    [Column("unlock_icon")]
    public string? UnlockIcon { get; set; }

    // Consumable, Gizmo
    [Indexed, Column("guild_upgrade_id")]
    public int? GuildUpgradeId { get; set; } // FK to GuildUpgradeEntity

    // MiniPet only
    [Indexed, Column("minipet_id")]
    public int? MinipetId { get; set; } // FK to MiniEntity

    // Salvage kit only
    [Column("charges")]
    public int? Charges { get; set; }

    // Weapon only
    [Indexed, Column("damage_type")]
    public string? DamageType { get; set; }

    [Column("min_power")]
    public int? MinPower { get; set; }

    [Column("max_power")]
    public int? MaxPower { get; set; }

    // UpgradeComponent only
    [Column("upgrade_suffix")]
    public string? UpgradeSuffix { get; set; }

    // Armor, Back, Trinket, UpgradeComponent, Weapon (InfixUpgrade)
    [Indexed, Column("infix_upgrade_stat_id")]
    public int? InfixUpgradeStatId { get; set; } // FK to ItemStatEntity

    [Indexed, Column("infix_buff_skill_id")]
    public int? InfixBuffSkillId { get; set; } // FK to SkillEntity

    [Column("infix_buff_description")]
    public string? InfixBuffDescription { get; set; }
}

/// <summary>An infusion/upgrade slot on an <see cref="ItemEntity"/> (armor, back, trinket, and weapon details).</summary>
[Table("item_infusion_slots")]
public class ItemInfusionSlotEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [Indexed, Column("socketed_item_id")]
    public int? SocketedItemId { get; set; } // FK to ItemEntity; null if slot is empty
}

/// <summary>An accepted infusion type flag on an <see cref="ItemInfusionSlotEntity"/> (e.g. "Infusion", "Defense").</summary>
[Table("item_infusion_slot_flags")]
public class ItemInfusionSlotFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_infusion_slot_id")]
    public int ItemInfusionSlotId { get; set; } // FK to ItemInfusionSlotEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A stat set choice offered by a stat-selectable <see cref="ItemEntity"/> (armor, back, trinket, weapon).</summary>
[Table("item_stat_choices")]
public class ItemStatChoiceEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("stat_id")]
    public int StatId { get; set; } // FK to ItemStatEntity
}

/// <summary>A single attribute bonus within an <see cref="ItemEntity"/>'s infix upgrade.</summary>
[Table("item_infix_attributes")]
public class ItemInfixAttributeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [NotNull, Column("modifier")]
    public int Modifier { get; set; }
}

/// <summary>An additional recipe unlocked by a consumable <see cref="ItemEntity"/>.</summary>
[Table("item_extra_recipes")]
public class ItemExtraRecipeEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("recipe_id")]
    public int RecipeId { get; set; } // FK to RecipeEntity
}

/// <summary>A skin unlocked by a consumable <see cref="ItemEntity"/>.</summary>
[Table("item_consumable_skins")]
public class ItemConsumableSkinEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("skin_id")]
    public int SkinId { get; set; } // FK to SkinEntity
}

/// <summary>A vendor id associated with a gizmo <see cref="ItemEntity"/>.</summary>
[Table("item_gizmo_vendor_ids")]
public class ItemGizmoVendorIdEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("vendor_id")]
    public int VendorId { get; set; }
}

/// <summary>An equipment-type flag on an upgrade component <see cref="ItemEntity"/> (e.g. "HeavyArmor", "Sword").</summary>
[Table("item_upgrade_component_flags")]
public class ItemUpgradeComponentFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>An infusion slot type an upgrade component <see cref="ItemEntity"/> fills (e.g. "Offense", "Defense").</summary>
[Table("item_infusion_upgrade_flags")]
public class ItemInfusionUpgradeFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A rune set bonus description on an upgrade component <see cref="ItemEntity"/>.</summary>
[Table("item_upgrade_bonuses")]
public class ItemUpgradeBonusEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("item_id")]
    public int ItemId { get; set; } // FK to ItemEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("bonus")]
    public string Bonus { get; set; } = string.Empty;
}
