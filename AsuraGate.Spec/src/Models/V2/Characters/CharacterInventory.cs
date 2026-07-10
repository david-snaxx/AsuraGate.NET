using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Characters;

/// <summary>Represents the full bag inventory of a character, including all equipped bag containers and their contents.</summary>
public record CharacterInventory
{
    /// <summary>Equipped bag containers in slot order.</summary>
    [JsonPropertyName("bags")]
    public InventoryBag[] Bags { get; init; } = [];
}

/// <summary>Represents a single equipped bag slot on a character within <see cref="CharacterInventory"/>.</summary>
public record InventoryBag
{
    /// <summary>Item ID of the bag container itself; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Total number of item slots in this bag.</summary>
    [JsonPropertyName("size")]
    public required int Size { get; init; }

    /// <summary>Ordered list of item slots in this bag; null entries represent empty slots.</summary>
    [JsonPropertyName("inventory")]
    public InventoryItem?[] Inventory { get; init; } = [];
}

/// <summary>Represents an item occupying a slot within an <see cref="InventoryBag"/>.</summary>
public record InventoryItem
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Stack size of this item.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>Number of consumable charges remaining; null if not applicable.</summary>
    [JsonPropertyName("charges")]
    public int? Charges { get; init; }

    /// <summary>Infusion item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("infusions")]
    public int[] Infusions { get; init; } = [];

    /// <summary>Upgrade component item IDs slotted in this item; each resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("upgrades")]
    public int[] Upgrades { get; init; } = [];

    /// <summary>Applied cosmetic skin ID; resolvable to a <see cref="V2.Skin"/>; null if no skin is applied.</summary>
    [JsonPropertyName("skin")]
    public int? Skin { get; init; }

    /// <summary>Applied stat set and its calculated bonuses; null if no stats are applied.</summary>
    [JsonPropertyName("stats")]
    public InventoryItemStats? Stats { get; init; }

    /// <summary>Dye color IDs applied to this item's dye slots; each resolvable to a <see cref="Dye"/>; null if no dyes applied.</summary>
    [JsonPropertyName("dyes")]
    public int[]? Dyes { get; init; }

    /// <summary>Item binding type: "Account" or "Character"; null if unbound.</summary>
    [JsonPropertyName("binding")]
    public string? Binding { get; init; }

    /// <summary>Name of the character this item is bound to; null if account-bound or unbound.</summary>
    [JsonPropertyName("bound_to")]
    public string? BoundTo { get; init; }
}

/// <summary>Represents the applied stat set on an inventory item within <see cref="CharacterInventory"/>.</summary>
public record InventoryItemStats
{
    /// <summary>Stat set ID; resolvable to an <see cref="ItemStat"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Calculated attribute bonuses provided by this stat set.</summary>
    [JsonPropertyName("attributes")]
    public required EquipmentAttributes Attributes { get; init; }
}
