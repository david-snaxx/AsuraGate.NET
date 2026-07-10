using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Account;

/// <summary>Represents an item stored in a bank tab slot of the authenticated account.</summary>
public record AccountBankItem
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Stack size of this item in the bank.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>Number of consumable charges remaining; null if not applicable.</summary>
    [JsonPropertyName("charges")]
    public int? Charges { get; init; }

    /// <summary>Applied cosmetic skin ID; resolvable to a <see cref="V2.Skin"/>; null if no skin is applied.</summary>
    [JsonPropertyName("skin")]
    public int? Skin { get; init; }

    /// <summary>Dye color IDs applied to this item's dye slots; each resolvable to a <see cref="Dye"/>; null if no dyes applied.</summary>
    [JsonPropertyName("dyes")]
    public int[]? Dyes { get; init; }

    /// <summary>Upgrade component item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("upgrades")]
    public int[] Upgrades { get; init; } = [];

    /// <summary>Upgrade slot indices that correspond positionally to the entries in <see cref="Upgrades"/>.</summary>
    [JsonPropertyName("upgrade_slot_indices")]
    public int[] UpgradeSlotIndices { get; init; } = [];

    /// <summary>Infusion item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("infusions")]
    public int[] Infusions { get; init; } = [];

    /// <summary>Item binding type: "Account" or "Character"; null if unbound.</summary>
    [JsonPropertyName("binding")]
    public string? Binding { get; init; }

    /// <summary>Name of the character this item is bound to; null if account-bound or unbound.</summary>
    [JsonPropertyName("bound_to")]
    public string? BoundTo { get; init; }

    /// <summary>Applied stat set and its calculated attribute bonuses; null if no stats are applied.</summary>
    [JsonPropertyName("stats")]
    public BankItemStats? Stats { get; init; }
}

/// <summary>Represents the applied stat set on an <see cref="AccountBankItem"/>.</summary>
public record BankItemStats
{
    /// <summary>Stat set ID; resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Calculated attribute bonuses provided by this stat set.</summary>
    [JsonPropertyName("attributes")]
    public required BankItemAttributes Attributes { get; init; }
}

/// <summary>Represents the individual attribute bonuses provided by a stat set on an <see cref="AccountBankItem"/>.</summary>
public record BankItemAttributes
{
    /// <summary>Agony resistance bonus; null if not provided by this stat set.</summary>
    [JsonPropertyName("AgonyResistance")]
    public double? AgonyResistance { get; init; }

    /// <summary>Concentration (boon duration) bonus; null if not provided.</summary>
    [JsonPropertyName("BoonDuration")]
    public double? BoonDuration { get; init; }

    /// <summary>Condition damage bonus; null if not provided.</summary>
    [JsonPropertyName("ConditionDamage")]
    public double? ConditionDamage { get; init; }

    /// <summary>Expertise (condition duration) bonus; null if not provided.</summary>
    [JsonPropertyName("ConditionDuration")]
    public double? ConditionDuration { get; init; }

    /// <summary>Ferocity (critical damage multiplier) bonus; null if not provided.</summary>
    [JsonPropertyName("CritDamage")]
    public double? CritDamage { get; init; }

    /// <summary>Healing power bonus; null if not provided.</summary>
    [JsonPropertyName("Healing")]
    public double? Healing { get; init; }

    /// <summary>Power bonus; null if not provided.</summary>
    [JsonPropertyName("Power")]
    public double? Power { get; init; }

    /// <summary>Precision bonus; null if not provided.</summary>
    [JsonPropertyName("Precision")]
    public double? Precision { get; init; }

    /// <summary>Toughness bonus; null if not provided.</summary>
    [JsonPropertyName("Toughness")]
    public double? Toughness { get; init; }

    /// <summary>Vitality bonus; null if not provided.</summary>
    [JsonPropertyName("Vitality")]
    public double? Vitality { get; init; }
}
