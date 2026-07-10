using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Guild;

/// <summary>Represents a material currently stored in the guild treasury and which upgrades require it.</summary>
public record GuildTreasuryItem
{
    /// <summary>Item ID of the material in the treasury; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>Current quantity of this item stored in the treasury.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }

    /// <summary>Guild upgrades that require this item, along with how many are still needed.</summary>
    [JsonPropertyName("needed_by")]
    public UpgradeNeed[] NeededBy { get; init; } = [];
}

/// <summary>Describes how many of a treasury item are required by a specific guild upgrade within <see cref="GuildTreasuryItem"/>.</summary>
public record UpgradeNeed
{
    /// <summary>Guild upgrade ID that needs this item; resolvable to a <see cref="GuildUpgrade"/>.</summary>
    [JsonPropertyName("upgrade_id")]
    public required int UpgradeId { get; init; }

    /// <summary>Total quantity of this item required by the upgrade.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
