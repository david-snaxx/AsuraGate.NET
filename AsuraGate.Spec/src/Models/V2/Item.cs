using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents an item in GW2, covering equipment, consumables, crafting materials, and more.</summary>
public record Item
{
    /// <summary>Unique item ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the item.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text or tooltip description; null for some items.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Item category (e.g., "Armor", "Weapon", "Consumable", "Trinket", "UpgradeComponent").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Item rarity tier (e.g., "Junk", "Fine", "Rare", "Exotic", "Ascended", "Legendary").</summary>
    [JsonPropertyName("rarity")]
    public required string Rarity { get; init; }

    /// <summary>Minimum character level required to equip or use this item.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>Value in copper coins when sold to an NPC vendor.</summary>
    [JsonPropertyName("vendor_value")]
    public required int VendorValue { get; init; }

    /// <summary>Default skin ID applied to this item; resolvable to a <see cref="Skin"/>; null if no default skin.</summary>
    [JsonPropertyName("default_skin")]
    public int? DefaultSkin { get; init; }

    /// <summary>List of behavioral flags (e.g., "Unique", "Soulbound", "AccountBound", "NoSell").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of game modes where this item can be used (e.g., "Pve", "Pvp", "Wvw").</summary>
    [JsonPropertyName("game_types")]
    public string[] GameTypes { get; init; } = [];

    /// <summary>List of race or profession restrictions for this item.</summary>
    [JsonPropertyName("restrictions")]
    public string[] Restrictions { get; init; } = [];

    /// <summary>In-game chat link code for sharing this item.</summary>
    [JsonPropertyName("chat_link")]
    public required string ChatLink { get; init; }

    /// <summary>URL to the item icon; null for some items.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>List of upgrade paths this item can transform into; see <see cref="ItemUpgrade"/>.</summary>
    [JsonPropertyName("upgrades_into")]
    public ItemUpgrade[] UpgradesInto { get; init; } = [];

    /// <summary>List of upgrade paths this item was transformed from; see <see cref="ItemUpgrade"/>.</summary>
    [JsonPropertyName("upgrades_from")]
    public ItemUpgrade[] UpgradesFrom { get; init; } = [];

    /// <summary>Raw JSON element of type-specific item details; use <see cref="GetDetails"/> to deserialize into the correct subtype.</summary>
    [JsonPropertyName("details")]
    public JsonElement? Details { get; init; }

    /// <summary>Deserializes <see cref="Details"/> into the correct <see cref="ItemDetails"/> subtype based on <see cref="Type"/>.</summary>
    public ItemDetails? GetDetails() => Type switch
    {
        "Armor" => Details?.Deserialize<ItemArmorDetails>(),
        "Back" => Details?.Deserialize<ItemBackDetails>(),
        "Bag" => Details?.Deserialize<ItemBagDetails>(),
        "Consumable" => Details?.Deserialize<ItemConsumableDetails>(),
        "Container" => Details?.Deserialize<ItemContainerDetails>(),
        "Gathering" => Details?.Deserialize<ItemGatheringDetails>(),
        "Gizmo" => Details?.Deserialize<ItemGizmoDetails>(),
        "MiniPet" => Details?.Deserialize<ItemMiniPetDetails>(),
        "Tool" => Details?.Deserialize<ItemSalvageKitDetails>(),
        "Trinket" => Details?.Deserialize<ItemTrinketDetails>(),
        "UpgradeComponent" => Details?.Deserialize<ItemUpgradeComponentDetails>(),
        "Weapon" => Details?.Deserialize<ItemWeaponDetails>(),
        _ => null
    };
}

/// <summary>Represents an upgrade path linking one <see cref="Item"/> to another via an upgrade recipe.</summary>
public record ItemUpgrade
{
    /// <summary>Upgrade type string describing the relationship (e.g., "Attunement", "Infusion").</summary>
    [JsonPropertyName("upgrade")]
    public required string Upgrade { get; init; }

    /// <summary>ID of the item this upgrades into or from; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }
}

/// <summary>Represents an infusion or upgrade slot on a piece of equipment.</summary>
public record InfusionSlot
{
    /// <summary>List of infusion type flags this slot accepts (e.g., "Infusion", "Enrichment", "Defense").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>ID of the item currently socketed in this slot; resolvable to an <see cref="Item"/>; null if empty.</summary>
    [JsonPropertyName("item_id")]
    public int? ItemId { get; init; }
}

/// <summary>Represents the stat bonuses and buff provided by an upgrade component applied to equipment.</summary>
public record InfixUpgrade
{
    /// <summary>Stat set ID of the infix upgrade; resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>List of individual attribute bonuses granted; see <see cref="AttributeBonus"/>.</summary>
    [JsonPropertyName("attributes")]
    public AttributeBonus[] Attributes { get; init; } = [];

    /// <summary>On-use or passive buff description; null if no buff; see <see cref="InfixBuff"/>.</summary>
    [JsonPropertyName("buff")]
    public InfixBuff? Buff { get; init; }
}

/// <summary>Represents a single attribute bonus within an <see cref="InfixUpgrade"/>.</summary>
public record AttributeBonus
{
    /// <summary>Attribute name (e.g., "Power", "Precision", "Toughness").</summary>
    [JsonPropertyName("attribute")]
    public required string Attribute { get; init; }

    /// <summary>Amount added to the attribute.</summary>
    [JsonPropertyName("modifier")]
    public required int Modifier { get; init; }
}

/// <summary>Represents the on-use or passive buff granted by an <see cref="InfixUpgrade"/>.</summary>
public record InfixBuff
{
    /// <summary>ID of the skill that provides this buff; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("skill_id")]
    public required int SkillId { get; init; }

    /// <summary>Description of the buff's effect shown in the tooltip; null for some buffs.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

/// <summary>
/// Polymorphic base for type-specific item details within an <see cref="Item"/>.
/// To check an items type you should check for the class name, not the "type" field for example:
/// <code>if (item.Details is ItemArmorDetails armor) { ... }</code>
/// Possible subtypes: <see cref="ItemArmorDetails"/>, <see cref="ItemBackDetails"/>, <see cref="ItemBagDetails"/>,
/// <see cref="ItemConsumableDetails"/>, <see cref="ItemContainerDetails"/>, <see cref="ItemGatheringDetails"/>,
/// <see cref="ItemGizmoDetails"/>, <see cref="ItemMiniPetDetails"/>, <see cref="ItemSalvageKitDetails"/>,
/// <see cref="ItemTrinketDetails"/>, <see cref="ItemUpgradeComponentDetails"/>, <see cref="ItemWeaponDetails"/>.
/// </summary>
public abstract record ItemDetails;

/// <summary>Type-specific details for armor <see cref="Item"/> types.</summary>
public record ItemArmorDetails : ItemDetails
{
    /// <summary>Armor slot (e.g., "Helm", "Coat", "Boots").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>Armor weight class (e.g., "Light", "Medium", "Heavy").</summary>
    [JsonPropertyName("weight_class")]
    public required string WeightClass { get; init; }

    /// <summary>Defense value provided by this armor piece.</summary>
    [JsonPropertyName("defense")]
    public required int Defense { get; init; }

    /// <summary>List of infusion slots on this armor; see <see cref="InfusionSlot"/>.</summary>
    [JsonPropertyName("infusion_slots")]
    public InfusionSlot[] InfusionSlots { get; init; } = [];

    /// <summary>Attribute adjustment factor applied to infix upgrade values based on item level.</summary>
    [JsonPropertyName("attribute_adjustment")]
    public required double AttributeAdjustment { get; init; }

    /// <summary>Stat bonuses and buff granted by this armor; null if not statted; see <see cref="InfixUpgrade"/>.</summary>
    [JsonPropertyName("infix_upgrade")]
    public InfixUpgrade? InfixUpgrade { get; init; }

    /// <summary>ID of the upgrade component socketed in the suffix slot; resolvable to an <see cref="Item"/>; null if empty.</summary>
    [JsonPropertyName("suffix_item_id")]
    public int? SuffixItemId { get; init; }

    /// <summary>Secondary suffix upgrade item ID; null if not applicable.</summary>
    [JsonPropertyName("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; init; }

    /// <summary>List of stat set IDs the player can choose from (for stat-selectable items); each resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("stat_choices")]
    public int[] StatChoices { get; init; } = [];
}

/// <summary>Type-specific details for back item <see cref="Item"/> types.</summary>
public record ItemBackDetails : ItemDetails
{
    /// <summary>List of infusion slots on this back item; see <see cref="InfusionSlot"/>.</summary>
    [JsonPropertyName("infusion_slots")]
    public InfusionSlot[] InfusionSlots { get; init; } = [];

    /// <summary>Attribute adjustment factor for infix upgrade values.</summary>
    [JsonPropertyName("attribute_adjustment")]
    public required double AttributeAdjustment { get; init; }

    /// <summary>Stat bonuses granted by this back item; null if not statted; see <see cref="InfixUpgrade"/>.</summary>
    [JsonPropertyName("infix_upgrade")]
    public InfixUpgrade? InfixUpgrade { get; init; }

    /// <summary>ID of the upgrade component in the suffix slot; resolvable to an <see cref="Item"/>; null if empty.</summary>
    [JsonPropertyName("suffix_item_id")]
    public int? SuffixItemId { get; init; }

    /// <summary>Secondary suffix upgrade item ID; null if not applicable.</summary>
    [JsonPropertyName("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; init; }

    /// <summary>List of choosable stat set IDs; each resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("stat_choices")]
    public int[] StatChoices { get; init; } = [];
}

/// <summary>Type-specific details for bag <see cref="Item"/> types.</summary>
public record ItemBagDetails : ItemDetails
{
    /// <summary>Number of inventory slots this bag provides.</summary>
    [JsonPropertyName("size")]
    public required int Size { get; init; }

    /// <summary>Whether items in this bag are excluded from auto-sell and auto-sort operations.</summary>
    [JsonPropertyName("no_sell_or_sort")]
    public required bool NoSellOrSort { get; init; }
}

/// <summary>Type-specific details for consumable <see cref="Item"/> types.</summary>
public record ItemConsumableDetails : ItemDetails
{
    /// <summary>Consumable subtype (e.g., "Food", "Utility", "Transmutation", "Unlock").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>Effect description shown in the tooltip; null for non-buff consumables.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Duration of the consumable's effect in milliseconds (buffs/food); null for instant-use consumables.</summary>
    [JsonPropertyName("duration_ms")]
    public int? DurationMs { get; init; }

    /// <summary>Unlock category when type is "Unlock" (e.g., "BagSlot", "BankTab", "CollectibleCapacity"); null otherwise.</summary>
    [JsonPropertyName("unlock_type")]
    public string? UnlockType { get; init; }

    /// <summary>Dye color ID unlocked by this consumable; resolvable to a <see cref="Dye"/>; null if not a dye unlock.</summary>
    [JsonPropertyName("color_id")]
    public int? ColorId { get; init; }

    /// <summary>Recipe ID unlocked by this consumable; null if not a recipe unlock.</summary>
    [JsonPropertyName("recipe_id")]
    public int? RecipeId { get; init; }

    /// <summary>Additional recipe IDs unlocked; empty if no extra recipes.</summary>
    [JsonPropertyName("extra_recipe_ids")]
    public int[] ExtraRecipeIds { get; init; } = [];

    /// <summary>Guild upgrade ID unlocked by this consumable; null if not a guild upgrade unlock.</summary>
    [JsonPropertyName("guild_upgrade_id")]
    public int? GuildUpgradeId { get; init; }

    /// <summary>Number of times this consumable applies its effect per use; null if not applicable.</summary>
    [JsonPropertyName("apply_count")]
    public int? ApplyCount { get; init; }

    /// <summary>Name override for the unlock (may differ from the item name); null if not applicable.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>Icon URL override for the unlock; null if not applicable.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>List of skin IDs unlocked by this consumable; each resolvable to a <see cref="Skin"/>.</summary>
    [JsonPropertyName("skins")]
    public int[] Skins { get; init; } = [];
}

/// <summary>Type-specific details for container <see cref="Item"/> types (bags, boxes, chests).</summary>
public record ItemContainerDetails : ItemDetails
{
    /// <summary>Container subtype (e.g., "Default", "GiftBox", "Immediate", "OpenUI").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;
}

/// <summary>Type-specific details for gathering tool <see cref="Item"/> types.</summary>
public record ItemGatheringDetails : ItemDetails
{
    /// <summary>Gathering tool subtype (e.g., "Foraging", "Logging", "Mining").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;
}

/// <summary>Type-specific details for gizmo <see cref="Item"/> types (single-use activatable items).</summary>
public record ItemGizmoDetails : ItemDetails
{
    /// <summary>Gizmo subtype (e.g., "Default", "ContainerKey", "RentableContractNpc", "UnlimitedConsumable").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>Guild upgrade associated with this gizmo; null if not applicable.</summary>
    [JsonPropertyName("guild_upgrade_id")]
    public int? GuildUpgradeId { get; init; }

    /// <summary>List of vendor IDs associated with this gizmo.</summary>
    [JsonPropertyName("vendor_ids")]
    public int[] VendorIds { get; init; } = [];
}

/// <summary>Type-specific details for miniature <see cref="Item"/> types.</summary>
public record ItemMiniPetDetails : ItemDetails
{
    /// <summary>ID of the miniature unlocked by this item; resolvable to a <see cref="Mini"/>.</summary>
    [JsonPropertyName("minipet_id")]
    public required int MinipetId { get; init; }
}

/// <summary>Type-specific details for salvage kit <see cref="Item"/> types.</summary>
public record ItemSalvageKitDetails : ItemDetails
{
    /// <summary>Salvage kit subtype (e.g., "Crude", "Basic", "Fine", "Journeyman", "Master").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>Number of uses remaining on the salvage kit.</summary>
    [JsonPropertyName("charges")]
    public required int Charges { get; init; }
}

/// <summary>Type-specific details for trinket <see cref="Item"/> types (amulets, rings, accessories).</summary>
public record ItemTrinketDetails : ItemDetails
{
    /// <summary>Trinket subtype (e.g., "Amulet", "Ring", "Accessory").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>List of infusion slots; see <see cref="InfusionSlot"/>.</summary>
    [JsonPropertyName("infusion_slots")]
    public InfusionSlot[] InfusionSlots { get; init; } = [];

    /// <summary>Attribute adjustment factor for infix upgrade values.</summary>
    [JsonPropertyName("attribute_adjustment")]
    public required double AttributeAdjustment { get; init; }

    /// <summary>Stat bonuses granted by this trinket; null if not statted; see <see cref="InfixUpgrade"/>.</summary>
    [JsonPropertyName("infix_upgrade")]
    public InfixUpgrade? InfixUpgrade { get; init; }

    /// <summary>ID of the upgrade component in the suffix slot; resolvable to an <see cref="Item"/>; null if empty.</summary>
    [JsonPropertyName("suffix_item_id")]
    public int? SuffixItemId { get; init; }

    /// <summary>Secondary suffix upgrade item ID; null if not applicable.</summary>
    [JsonPropertyName("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; init; }

    /// <summary>List of choosable stat set IDs; each resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("stat_choices")]
    public int[] StatChoices { get; init; } = [];
}

/// <summary>Type-specific details for upgrade component <see cref="Item"/> types (sigils, runes, gems, orbs).</summary>
public record ItemUpgradeComponentDetails : ItemDetails
{
    /// <summary>Upgrade component subtype (e.g., "Sigil", "Rune", "Gem", "Default").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>List of equipment types this upgrade can be applied to (e.g., "HeavyArmor", "Sword").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of infusion slot types this upgrade fills (e.g., "Offense", "Defense", "Utility").</summary>
    [JsonPropertyName("infusion_upgrade_flags")]
    public string[] InfusionUpgradeFlags { get; init; } = [];

    /// <summary>Suffix text appended to the equipment name when this upgrade is applied; null for some upgrades.</summary>
    [JsonPropertyName("suffix")]
    public string? Suffix { get; init; }

    /// <summary>Stat bonuses provided by this upgrade; null if no stat bonuses; see <see cref="InfixUpgrade"/>.</summary>
    [JsonPropertyName("infix_upgrade")]
    public InfixUpgrade? InfixUpgrade { get; init; }

    /// <summary>List of set bonus descriptions (runes only, one entry per stacking bonus).</summary>
    [JsonPropertyName("bonuses")]
    public string[] Bonuses { get; init; } = [];
}

/// <summary>Type-specific details for weapon <see cref="Item"/> types.</summary>
public record ItemWeaponDetails : ItemDetails
{
    /// <summary>Weapon type (e.g., "Sword", "Staff", "Longbow", "Shield").</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;

    /// <summary>Damage type (e.g., "Physical", "Fire", "Ice", "Lightning").</summary>
    [JsonPropertyName("damage_type")]
    public required string DamageType { get; init; }

    /// <summary>Minimum power damage value of this weapon.</summary>
    [JsonPropertyName("min_power")]
    public required int MinPower { get; init; }

    /// <summary>Maximum power damage value of this weapon.</summary>
    [JsonPropertyName("max_power")]
    public required int MaxPower { get; init; }

    /// <summary>Defense value (for off-hand weapons like shields and foci).</summary>
    [JsonPropertyName("defense")]
    public required int Defense { get; init; }

    /// <summary>List of infusion slots on this weapon; see <see cref="InfusionSlot"/>.</summary>
    [JsonPropertyName("infusion_slots")]
    public InfusionSlot[] InfusionSlots { get; init; } = [];

    /// <summary>Attribute adjustment factor for infix upgrade values.</summary>
    [JsonPropertyName("attribute_adjustment")]
    public required double AttributeAdjustment { get; init; }

    /// <summary>Stat bonuses granted by this weapon; null if not statted; see <see cref="InfixUpgrade"/>.</summary>
    [JsonPropertyName("infix_upgrade")]
    public InfixUpgrade? InfixUpgrade { get; init; }

    /// <summary>ID of the upgrade component in the suffix slot; resolvable to an <see cref="Item"/>; null if empty.</summary>
    [JsonPropertyName("suffix_item_id")]
    public int? SuffixItemId { get; init; }

    /// <summary>Secondary suffix upgrade item ID; null if not applicable.</summary>
    [JsonPropertyName("secondary_suffix_item_id")]
    public string? SecondarySuffixItemId { get; init; }

    /// <summary>List of choosable stat set IDs; each resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("stat_choices")]
    public int[] StatChoices { get; init; } = [];
}
