using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a single tab (section) of the guild stash.</summary>
public record GuildStashSection
{
    /// <summary>Guild upgrade ID that unlocked this stash tab; resolvable to a <see cref="GuildUpgrade"/>.</summary>
    [JsonPropertyName("upgrade_id")]
    public required int UpgradeId { get; init; }

    /// <summary>Number of item slots in this stash tab.</summary>
    [JsonPropertyName("size")]
    public required int Size { get; init; }

    /// <summary>Amount of coins (in copper) stored in this tab.</summary>
    [JsonPropertyName("coins")]
    public required int Coins { get; init; }

    /// <summary>Note or label attached to this stash tab.</summary>
    [JsonPropertyName("note")]
    public required string Note { get; init; }

    /// <summary>Ordered item slots in this stash tab; null entries represent empty slots.</summary>
    [JsonPropertyName("inventory")]
    public GuildStashItem?[] Inventory { get; init; } = [];
}

/// <summary>Represents an item occupying a slot in a <see cref="GuildStashSection"/>.</summary>
public record GuildStashItem
{
    /// <summary>Item ID; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Stack size of this item.</summary>
    [JsonPropertyName("count")]
    public required int Count { get; init; }
}
