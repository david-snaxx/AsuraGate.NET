using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.WizardsVault;

/// <summary>Represents a Wizard's Vault objective from the static catalog, defining a task players can complete to earn Astral Acclaim.</summary>
public record WizardsVaultObjective
{
    /// <summary>Unique objective ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display title of the objective.</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Activity track this objective belongs to (e.g., "PvE", "PvP", "WvW").</summary>
    [JsonPropertyName("track")]
    public required string Track { get; init; }

    /// <summary>Amount of Astral Acclaim awarded for completing this objective.</summary>
    [JsonPropertyName("acclaim")]
    public required int Acclaim { get; init; }
}
