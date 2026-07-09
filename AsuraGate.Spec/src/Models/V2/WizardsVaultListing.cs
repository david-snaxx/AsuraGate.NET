using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a purchasable item listing in the Wizard's Vault shop.</summary>
public record WizardsVaultListing
{
    /// <summary>Unique listing ID string.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>ID of the item offered by this listing; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("item_id")]
    public required int ItemId { get; init; }

    /// <summary>Number of items received per purchase.</summary>
    [JsonPropertyName("item_count")]
    public required int ItemCount { get; init; }

    /// <summary>Listing category (e.g., "Featured", "Normal").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Astral Acclaim cost required to purchase this listing.</summary>
    [JsonPropertyName("cost")]
    public required int Cost { get; init; }
}
