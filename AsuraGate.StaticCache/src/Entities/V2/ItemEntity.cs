using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Item"/>.
/// </summary>
[Table("items")]
public class ItemEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("rarity")]
    public string Rarity { get; set; } = string.Empty;

    [NotNull]
    [Column("level")]
    public int Level { get; set; }

    [NotNull]
    [Column("vendor_value")]
    public int VendorValue { get; set; }

    [Column("default_skin")]
    public int? DefaultSkin { get; set; }

    [NotNull]
    [Column("chat_link")]
    public string ChatLink { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }
}

/// <summary>Behavior flag on an <see cref="ItemEntity"/>.</summary>
[Table("item_flags")]
public class ItemFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Game mode this <see cref="ItemEntity"/> can be used in.</summary>
[Table("item_game_types")]
public class ItemGameTypeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("game_type")]
    public string GameType { get; set; } = string.Empty;
}

/// <summary>Race/profession restriction on an <see cref="ItemEntity"/>.</summary>
[Table("item_restrictions")]
public class ItemRestrictionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("restriction")]
    public string Restriction { get; set; } = string.Empty;
}

/// <summary>An upgrade path an <see cref="ItemEntity"/> can transform into or from.</summary>
[Table("item_upgrade_paths")]
public class ItemUpgradePathEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("direction")]
    public bool IsInto { get; set; } // true = upgrades_into, false = upgrades_from

    [NotNull]
    [Column("upgrade")]
    public string Upgrade { get; set; } = string.Empty;

    [NotNull]
    [Column("target_item_id")]
    public int TargetItemId { get; set; }
}

/// <summary>
/// Type-specific details for an <see cref="ItemEntity"/>, one row per item that has a <c>details</c>
/// object. This is a union of every subtype's scalar fields (only the columns relevant to
/// <see cref="ItemEntity.Type"/> are populated) - the same discriminator-table idea as Achievement's
/// reward table, just wider because Item has many more subtypes and fields. List-valued fields (infusion
/// slots, stat choices, etc.) live in their own child tables below, keyed directly by ItemId since
/// details is one-to-one with the item.
/// </summary>
[Table("item_details")]
public class ItemDetailsEntity
{
    [PrimaryKey]
    [Column("item_id")]
    public int ItemId { get; set; }

    /// <summary>The details object's own "type" sub-field (e.g. armor slot, weapon type, consumable subtype) - distinct from <see cref="ItemEntity.Type"/>.</summary>
    [Column("details_subtype")]
    public string? DetailsSubtype { get; set; }

    [Column("weight_class")]
    public string? WeightClass { get; set; } // Armor

    [Column("defense")]
    public int? Defense { get; set; } // Armor, Weapon

    [Column("attribute_adjustment")]
    public double? AttributeAdjustment { get; set; } // Armor, Back, Trinket, Weapon

    [Column("suffix_item_id")]
    public int? SuffixItemId { get; set; } // Armor, Back, Trinket, Weapon

    [Column("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; set; } // Armor, Back, Trinket, Weapon

    [Column("size")]
    public int? Size { get; set; } // Bag

    [Column("no_sell_or_sort")]
    public bool? NoSellOrSort { get; set; } // Bag

    [Column("consumable_description")]
    public string? ConsumableDescription { get; set; } // Consumable

    [Column("duration_ms")]
    public int? DurationMs { get; set; } // Consumable

    [Column("unlock_type")]
    public string? UnlockType { get; set; } // Consumable

    [Column("color_id")]
    public int? ColorId { get; set; } // Consumable

    [Column("recipe_id")]
    public int? RecipeId { get; set; } // Consumable

    [Column("guild_upgrade_id")]
    public int? GuildUpgradeId { get; set; } // Consumable, Gizmo

    [Column("apply_count")]
    public int? ApplyCount { get; set; } // Consumable

    [Column("consumable_name")]
    public string? ConsumableName { get; set; } // Consumable (name override)

    [Column("consumable_icon")]
    public string? ConsumableIcon { get; set; } // Consumable (icon override)

    [Column("minipet_id")]
    public int? MinipetId { get; set; } // MiniPet

    [Column("charges")]
    public int? Charges { get; set; } // SalvageKit

    [Column("damage_type")]
    public string? DamageType { get; set; } // Weapon

    [Column("min_power")]
    public int? MinPower { get; set; } // Weapon

    [Column("max_power")]
    public int? MaxPower { get; set; } // Weapon

    [Column("suffix")]
    public string? Suffix { get; set; } // UpgradeComponent

    [Column("infix_upgrade_id")]
    public int? InfixUpgradeId { get; set; } // Armor, Back, Trinket, UpgradeComponent, Weapon

    [Column("infix_upgrade_buff_skill_id")]
    public int? InfixUpgradeBuffSkillId { get; set; }

    [Column("infix_upgrade_buff_description")]
    public string? InfixUpgradeBuffDescription { get; set; }
}

/// <summary>Infusion slot on an <see cref="ItemDetailsEntity"/> (Armor/Back/Trinket/Weapon).</summary>
[Table("item_infusion_slots")]
public class ItemInfusionSlotEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("socketed_item_id")]
    public int? SocketedItemId { get; set; }
}

/// <summary>
/// Infusion type flag on an <see cref="ItemInfusionSlotEntity"/>. Carries the slot's ItemId + OrderIndex
/// down directly instead of the slot's surrogate id, since slots have no natural key of their own.
/// </summary>
[Table("item_infusion_slot_flags")]
public class ItemInfusionSlotFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("slot_order_index")]
    public int SlotOrderIndex { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Choosable stat set ID on an <see cref="ItemDetailsEntity"/> (Armor/Back/Trinket/Weapon).</summary>
[Table("item_stat_choices")]
public class ItemStatChoiceEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("stat_id")]
    public int StatId { get; set; }
}

/// <summary>Attribute bonus granted by an <see cref="ItemDetailsEntity"/>'s infix upgrade.</summary>
[Table("item_infix_upgrade_attributes")]
public class ItemInfixUpgradeAttributeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("attribute")]
    public string Attribute { get; set; } = string.Empty;

    [NotNull]
    [Column("modifier")]
    public int Modifier { get; set; }
}

/// <summary>Extra recipe ID unlocked by a Consumable <see cref="ItemDetailsEntity"/>.</summary>
[Table("item_extra_recipes")]
public class ItemExtraRecipeEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("recipe_id")]
    public int RecipeId { get; set; }
}

/// <summary>Skin unlocked by a Consumable <see cref="ItemDetailsEntity"/>.</summary>
[Table("item_unlock_skins")]
public class ItemUnlockSkinEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("skin_id")]
    public int SkinId { get; set; }
}

/// <summary>Vendor ID associated with a Gizmo <see cref="ItemDetailsEntity"/>.</summary>
[Table("item_vendors")]
public class ItemVendorEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("vendor_id")]
    public int VendorId { get; set; }
}

/// <summary>Equipment-type flag on an UpgradeComponent <see cref="ItemDetailsEntity"/> (distinct from <see cref="ItemFlagEntity"/>).</summary>
[Table("item_upgrade_component_flags")]
public class ItemUpgradeComponentFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Infusion upgrade slot-type flag on an UpgradeComponent <see cref="ItemDetailsEntity"/>.</summary>
[Table("item_infusion_upgrade_flags")]
public class ItemInfusionUpgradeFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Set bonus description on a rune-type UpgradeComponent <see cref="ItemDetailsEntity"/>.</summary>
[Table("item_upgrade_component_bonuses")]
public class ItemUpgradeComponentBonusEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("item_id")]
    public int ItemId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("bonus")]
    public string Bonus { get; set; } = string.Empty;
}
