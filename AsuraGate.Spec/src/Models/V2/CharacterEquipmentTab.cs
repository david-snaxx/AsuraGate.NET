using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a saved equipment tab (loadout slot) for a character.</summary>
public record CharacterEquipmentTab
{
    /// <summary>One-based index of this equipment tab.</summary>
    [JsonPropertyName("tab")]
    public required int Tab { get; init; }

    /// <summary>Display name given to this equipment tab; may be empty.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Whether this tab is the currently active equipment loadout.</summary>
    [JsonPropertyName("is_active")]
    public required bool IsActive { get; init; }

    /// <summary>Equipped items in this tab.</summary>
    [JsonPropertyName("equipment")]
    public TabEquipmentItem[] Equipment { get; init; } = [];

    /// <summary>PvP-specific equipment selections (amulet, rune, sigils) for this tab; null if not configured.</summary>
    [JsonPropertyName("equipment_pvp")]
    public EquipmentPvp? EquipmentPvp { get; init; }
}

/// <summary>Represents a single equipped item in a <see cref="CharacterEquipmentTab"/>.</summary>
public record TabEquipmentItem
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Equipment slot name (e.g., "Helm", "Coat", "Weapon_A1", "Backpack", "Accessory1").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>Applied cosmetic skin ID; resolvable to a <see cref="V2.Skin"/>; null if no skin is applied.</summary>
    [JsonPropertyName("skin")]
    public int? Skin { get; init; }

    /// <summary>Upgrade component item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("upgrades")]
    public int[] Upgrades { get; init; } = [];

    /// <summary>Infusion item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("infusions")]
    public int[] Infusions { get; init; } = [];

    /// <summary>Item binding type: "Account" or "Character"; null if unbound.</summary>
    [JsonPropertyName("binding")]
    public string? Binding { get; init; }

    /// <summary>Name of the character this item is bound to; null if account-bound or unbound.</summary>
    [JsonPropertyName("bound_to")]
    public string? BoundTo { get; init; }

    /// <summary>Storage location of this item: "Equipped" or "Armory" (legendary armory).</summary>
    [JsonPropertyName("location")]
    public required string Location { get; init; }

    /// <summary>Dye color IDs applied to this item's dye slots; each resolvable to a <see cref="Dye"/>; null if no dyes applied.</summary>
    [JsonPropertyName("dyes")]
    public int[]? Dyes { get; init; }

    /// <summary>Applied stat set and its calculated attribute bonuses; null if no stats are applied.</summary>
    [JsonPropertyName("stats")]
    public TabEquipmentStats? Stats { get; init; }
}

/// <summary>Represents the applied stat set on an equipped item within a <see cref="CharacterEquipmentTab"/>.</summary>
public record TabEquipmentStats
{
    /// <summary>Stat set ID; resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Calculated attribute bonuses provided by this stat set.</summary>
    [JsonPropertyName("attributes")]
    public required EquipmentAttributes Attributes { get; init; }
}

/// <summary>Represents the PvP-specific equipment selections in a <see cref="CharacterEquipmentTab"/>.</summary>
public record EquipmentPvp
{
    /// <summary>ID of the PvP amulet selected for this tab; resolvable to a <see cref="PvpAmulet"/>; null if none selected.</summary>
    [JsonPropertyName("amulet")]
    public int? Amulet { get; init; }

    /// <summary>Item ID of the PvP rune selected for this tab; resolvable to an <see cref="Item"/>; null if none selected.</summary>
    [JsonPropertyName("rune")]
    public int? Rune { get; init; }

    /// <summary>Up to four PvP sigil item IDs selected for this tab; each resolvable to an <see cref="Item"/>; null entries indicate empty slots.</summary>
    [JsonPropertyName("sigils")]
    public int[]? Sigils { get; init; }
}
