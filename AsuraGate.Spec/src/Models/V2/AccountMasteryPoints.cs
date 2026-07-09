using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the mastery point totals and unlocked mastery points for the authenticated account.</summary>
public record AccountMasteryPoints
{
    /// <summary>Per-region mastery point totals summarizing earned and spent points.</summary>
    [JsonPropertyName("totals")]
    public MasteryPointTotal[] Totals { get; init; } = [];

    /// <summary>Mastery points that have been collected and are available to spend on this account.</summary>
    [JsonPropertyName("unlocked")]
    public MasteryPointUnlocked[] Unlocked { get; init; } = [];
}

/// <summary>Summarizes mastery point earnings and expenditures for a single region within <see cref="AccountMasteryPoints"/>.</summary>
public record MasteryPointTotal
{
    /// <summary>Mastery region name (e.g., "CentralTyria", "Maguuma", "Desert", "Tundra", "Jade", "SkyScale").</summary>
    [JsonPropertyName("region")]
    public required string Region { get; init; }

    /// <summary>Total mastery points spent on unlocking mastery levels in this region.</summary>
    [JsonPropertyName("spent")]
    public required int Spent { get; init; }

    /// <summary>Total mastery points earned from map completions and achievements in this region.</summary>
    [JsonPropertyName("earned")]
    public required int Earned { get; init; }
}

/// <summary>Represents a single unlocked mastery point within <see cref="AccountMasteryPoints"/>.</summary>
public record MasteryPointUnlocked
{
    /// <summary>Mastery point ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Mastery region this point belongs to (e.g., "CentralTyria", "Maguuma").</summary>
    [JsonPropertyName("region")]
    public required string Region { get; init; }
}
