using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Characters;

/// <summary>Represents the full equipment loadout of a character, spanning all equipment tabs.</summary>
public record CharacterEquipment
{
    /// <summary>All equipped items across all equipment tabs.</summary>
    [JsonPropertyName("equipment")]
    public EquipmentItem[] Equipment { get; init; } = [];
}

/// <summary>Represents a single item in the character's equipment across all tabs.</summary>
public record EquipmentItem
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Equipment slot name (e.g., "Helm", "Coat", "Weapon_A1", "Backpack", "Accessory1", "Ring1").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>Infusion item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("infusions")]
    public int[] Infusions { get; init; } = [];

    /// <summary>Upgrade component item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("upgrades")]
    public int[] Upgrades { get; init; } = [];

    /// <summary>Applied cosmetic skin ID; resolvable to a <see cref="V2.Skin"/>; null if no skin is applied.</summary>
    [JsonPropertyName("skin")]
    public int? Skin { get; init; }

    /// <summary>Applied stat set and its calculated attribute bonuses; null if no stats are applied.</summary>
    [JsonPropertyName("stats")]
    public EquipmentStats? Stats { get; init; }

    /// <summary>Item binding type: "Account" or "Character"; null if unbound.</summary>
    [JsonPropertyName("binding")]
    public string? Binding { get; init; }

    /// <summary>Name of the character this item is bound to; null if account-bound or unbound.</summary>
    [JsonPropertyName("bound_to")]
    public string? BoundTo { get; init; }

    /// <summary>Storage location: "Equipped" if actively worn, or "Armory" if sourced from the legendary armory.</summary>
    [JsonPropertyName("location")]
    public required string Location { get; init; }

    /// <summary>One-based equipment tab indices that include this item.</summary>
    [JsonPropertyName("tabs")]
    public int[] Tabs { get; init; } = [];

    /// <summary>Number of consumable charges remaining; null if not applicable.</summary>
    [JsonPropertyName("charges")]
    public int? Charges { get; init; }

    /// <summary>Dye color IDs applied to this item's dye slots; each resolvable to a <see cref="Dye"/>; null if no dyes applied.</summary>
    [JsonPropertyName("dyes")]
    public int[]? Dyes { get; init; }
}

/// <summary>Represents the applied stat set on an equipped item.</summary>
public record EquipmentStats
{
    /// <summary>Stat set ID; resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Calculated attribute bonuses provided by this stat set.</summary>
    [JsonPropertyName("attributes")]
    public required EquipmentAttributes Attributes { get; init; }
}

/// <summary>Represents the individual attribute bonuses provided by a stat set on an equipped item.</summary>
public record EquipmentAttributes
{
    /// <summary>Power bonus; null if not provided.</summary>
    [JsonPropertyName("Power")]
    public int? Power { get; init; }

    /// <summary>Precision bonus; null if not provided.</summary>
    [JsonPropertyName("Precision")]
    public int? Precision { get; init; }

    /// <summary>Toughness bonus; null if not provided.</summary>
    [JsonPropertyName("Toughness")]
    public int? Toughness { get; init; }

    /// <summary>Vitality bonus; null if not provided.</summary>
    [JsonPropertyName("Vitality")]
    public int? Vitality { get; init; }

    /// <summary>Condition damage bonus; null if not provided.</summary>
    [JsonPropertyName("ConditionDamage")]
    public int? ConditionDamage { get; init; }

    /// <summary>Expertise (condition duration) bonus; null if not provided.</summary>
    [JsonPropertyName("ConditionDuration")]
    public int? ConditionDuration { get; init; }

    /// <summary>Healing power bonus; null if not provided.</summary>
    [JsonPropertyName("Healing")]
    public int? Healing { get; init; }

    /// <summary>Concentration (boon duration) bonus; null if not provided.</summary>
    [JsonPropertyName("BoonDuration")]
    public int? BoonDuration { get; init; }

    /// <summary>Agony resistance bonus; null if not provided.</summary>
    [JsonPropertyName("AgonyResistance")]
    public int? AgonyResistance { get; init; }
}
