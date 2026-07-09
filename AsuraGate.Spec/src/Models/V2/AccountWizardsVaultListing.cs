using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a single item listing in the authenticated account's Wizard's Vault shop.</summary>
public record AccountWizardsVaultListing
{
    /// <summary>Unique listing ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>URL of the listing's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Display name of this listing.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the item or bundle offered in this listing.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Listing type (e.g., "Normal", "Featured").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Cost in astral acclaim to purchase this listing.</summary>
    [JsonPropertyName("cost")]
    public required int Cost { get; init; }

    /// <summary>Number of times the account has purchased this listing in the current cycle.</summary>
    [JsonPropertyName("purchased")]
    public required int Purchased { get; init; }

    /// <summary>Whether this listing can only be purchased once per account lifetime.</summary>
    [JsonPropertyName("limit_once_per_account")]
    public required bool LimitOncePerAccount { get; init; }
}
