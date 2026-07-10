using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Wvw;

/// <summary>Represents the upgrade progression track for a WvW objective, unlocked incrementally as dolyaks are delivered.</summary>
public record WvwUpgrade
{
    /// <summary>Objective ID this upgrade track belongs to; matches the <see cref="WvwObjective"/> ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Ordered list of upgrade tiers unlocked by dolyak deliveries.</summary>
    [JsonPropertyName("tiers")]
    public WvwUpgradeTier[] Tiers { get; init; } = [];
}

/// <summary>Represents a single upgrade tier within a <see cref="WvwUpgrade"/> progression track.</summary>
public record WvwUpgradeTier
{
    /// <summary>Display name of this tier (e.g., "Secured", "Reinforced", "Fortified").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Number of dolyak deliveries required to unlock this tier.</summary>
    [JsonPropertyName("yaks_required")]
    public required int YaksRequired { get; init; }

    /// <summary>Individual upgrades unlocked when this tier is reached.</summary>
    [JsonPropertyName("upgrade")]
    public WvwUpgradeItem[] Upgrades { get; init; } = [];
}

/// <summary>Represents a single upgrade unlocked within a <see cref="WvwUpgradeTier"/>.</summary>
public record WvwUpgradeItem
{
    /// <summary>Display name of this upgrade (e.g., "Supply Depot", "Cannons").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the upgrade's effect on the objective.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the upgrade's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }
}
