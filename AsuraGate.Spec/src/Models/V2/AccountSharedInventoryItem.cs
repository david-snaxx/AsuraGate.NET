using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents an item stored in the authenticated account's shared inventory slots.</summary>
public record AccountSharedInventoryItem
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

    /// <summary>Applied cosmetic skin ID; resolvable to a <see cref="Model.Skin"/>; null if no skin is applied.</summary>
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
}
