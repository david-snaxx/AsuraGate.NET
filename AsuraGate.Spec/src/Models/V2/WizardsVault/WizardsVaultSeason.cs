using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.WizardsVault;

/// <summary>Represents the current Wizard's Vault season, including its active listings and objectives.</summary>
public record WizardsVaultSeason
{
    /// <summary>Display title of the season.</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Timestamp when the season began.</summary>
    [JsonPropertyName("start")]
    public required DateTime Start { get; init; }

    /// <summary>Timestamp when the season ends.</summary>
    [JsonPropertyName("end")]
    public required DateTime End { get; init; }

    /// <summary>Listing IDs available in the Wizard's Vault shop this season; each resolvable to a <see cref="WizardsVaultListing"/>.</summary>
    [JsonPropertyName("listings")]
    public int[] Listings { get; init; } = [];

    /// <summary>Objective IDs available this season; each resolvable to a <see cref="WizardsVaultObjective"/>.</summary>
    [JsonPropertyName("objectives")]
    public int[] Objectives { get; init; } = [];
}
