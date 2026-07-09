using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the authenticated account's special Wizard's Vault objectives and their completion state.</summary>
public record AccountWizardsVaultSpecial
{
    /// <summary>Special Wizard's Vault objectives currently available to the account.</summary>
    [JsonPropertyName("objectives")]
    public required List<AccountWizardsVaultDailyObjective> Objectives { get; init; }
}

/// <summary>Represents a single special Wizard's Vault objective.</summary>
public record AccountWizardsVaultSpecialObjective
{
    /// <summary>Unique objective ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display title describing what must be done to complete this objective.</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Activity track this objective contributes to (e.g., "PvE", "PvP", "WvW").</summary>
    [JsonPropertyName("track")]
    public required string Track { get; init; }

    /// <summary>Amount of astral acclaim awarded upon completing this objective.</summary>
    [JsonPropertyName("acclaim")]
    public required int Acclaim { get; init; }

    /// <summary>Current progress toward completing this objective.</summary>
    [JsonPropertyName("progress_current")]
    public required int ProgressCurrent { get; init; }

    /// <summary>Total progress required to complete this objective.</summary>
    [JsonPropertyName("progress_complete")]
    public required int ProgressComplete { get; init; }

    /// <summary>Whether the astral acclaim reward for this objective has been claimed.</summary>
    [JsonPropertyName("claimed")]
    public required bool Claimed { get; init; }

    /// <summary>Amount of astral acclaim periodically awarded for ongoing progress; null if not applicable.</summary>
    [JsonPropertyName("periodic_acclaim")]
    public int? PeriodicAcclaim { get; init; }
}
