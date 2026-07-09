using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the authenticated account's daily Wizard's Vault objective progress and meta reward state.</summary>
public record AccountWizardsVaultDaily
{
    /// <summary>Current progress toward the daily meta reward threshold.</summary>
    [JsonPropertyName("meta_progress_current")]
    public required int MetaProgressCurrent { get; init; }

    /// <summary>Total astral acclaim required to earn the daily meta reward.</summary>
    [JsonPropertyName("meta_progress_complete")]
    public required int MetaProgressComplete { get; init; }

    /// <summary>ID of the item granted as the daily meta reward; resolvable to an <see cref="Item"/>.</summary>
    [JsonPropertyName("meta_reward_item_id")]
    public int MetaRewardItemId { get; init; }

    /// <summary>Amount of astral acclaim awarded alongside the daily meta reward item.</summary>
    [JsonPropertyName("meta_reward_astral ")]
    public int MetaRewardAstral { get; init; }

    /// <summary>Whether the daily meta reward has already been claimed this cycle.</summary>
    [JsonPropertyName("meta_reward_claimed")]
    public bool MetaRewardClaimed { get; init; }

    /// <summary>List of daily Wizard's Vault objectives for the current day.</summary>
    [JsonPropertyName("objectives")]
    public required List<AccountWizardsVaultDailyObjective> Objectives { get; init; }
}

/// <summary>Represents a single daily Wizard's Vault objective within <see cref="AccountWizardsVaultDaily"/>.</summary>
public record AccountWizardsVaultDailyObjective
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
}
