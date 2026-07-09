using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a guild upgrade available to be built or already built in a guild hall.</summary>
public record GuildUpgrade
{
    /// <summary>Unique guild upgrade ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the upgrade.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of what this upgrade provides to the guild.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Upgrade category type (e.g., "AccumulatingCurrency", "BankBag", "Boost", "Hub", "Queue", "Unlock").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>URL to the upgrade's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Time required to build this upgrade, in minutes.</summary>
    [JsonPropertyName("build_time")]
    public required int BuildTime { get; init; }

    /// <summary>Minimum guild level required to build this upgrade.</summary>
    [JsonPropertyName("required_level")]
    public required int RequiredLevel { get; init; }

    /// <summary>Guild experience awarded when this upgrade is completed.</summary>
    [JsonPropertyName("experience")]
    public required int Experience { get; init; }

    /// <summary>Guild upgrade IDs that must be built before this upgrade becomes available; each resolvable to a <see cref="GuildUpgrade"/>.</summary>
    [JsonPropertyName("prerequisites")]
    public int[] Prerequisites { get; init; } = [];

    /// <summary>Resource costs required to build this upgrade.</summary>
    [JsonPropertyName("costs")]
    public UpgradeCost[] Costs { get; init; } = [];

    /// <summary>Maximum number of item slots in the bag unlocked by this upgrade; null for non-bag upgrade types.</summary>
    [JsonPropertyName("bag_max_items")]
    public int? BagMaxItems { get; init; }

    /// <summary>Maximum amount of coins (in copper) that can be stored in the bag unlocked by this upgrade; null for non-bag upgrade types.</summary>
    [JsonPropertyName("bag_max_coins")]
    public int? BagMaxCoins { get; init; }
}

/// <summary>Represents a single resource cost required to build a <see cref="GuildUpgrade"/>.</summary>
public record UpgradeCost
{
    /// <summary>Cost type: "Item" (requires an item), "Collectible" (requires a material storage item), or "Currency" (requires a guild currency).</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Display name of this cost entry.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Amount of this resource required.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>Item ID required for "Item" or "Collectible" cost types; resolvable to an <see cref="Item"/>; null for currency costs.</summary>
    [JsonPropertyName("item_id")]
    public int? ItemId { get; init; }
}
