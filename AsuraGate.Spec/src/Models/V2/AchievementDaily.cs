using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the full set of daily achievements available today, organized by game mode.</summary>
public record AchievementDaily
{
    /// <summary>PvE daily achievements available today.</summary>
    [JsonPropertyName("pve")]
    public DailyAchievement[] Pve { get; init; } = [];

    /// <summary>PvP daily achievements available today.</summary>
    [JsonPropertyName("pvp")]
    public DailyAchievement[] Pvp { get; init; } = [];

    /// <summary>WvW daily achievements available today.</summary>
    [JsonPropertyName("wvw")]
    public DailyAchievement[] Wvw { get; init; } = [];

    /// <summary>Fractal daily achievements available today.</summary>
    [JsonPropertyName("fractals")]
    public DailyAchievement[] Fractals { get; init; } = [];

    /// <summary>Special daily achievements available today.</summary>
    [JsonPropertyName("special")]
    public DailyAchievement[] Special { get; init; } = [];
}

/// <summary>Represents a single daily achievement entry within <see cref="AchievementDaily"/>.</summary>
public record DailyAchievement
{
    /// <summary>Achievement ID; resolvable to an <see cref="Achievement"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Character level range required to access this daily achievement.</summary>
    [JsonPropertyName("level")]
    public required DailyLevelRange Level { get; init; }

    /// <summary>Game expansion required to access this daily achievement; null if always accessible.</summary>
    [JsonPropertyName("required_access")]
    public DailyRequiredAccess? RequiredAccess { get; init; }
}

/// <summary>Represents the character level eligibility range for a <see cref="DailyAchievement"/>.</summary>
public record DailyLevelRange
{
    /// <summary>Minimum character level required to access this daily achievement.</summary>
    [JsonPropertyName("min")]
    public required int Min { get; init; }

    /// <summary>Maximum character level at which this daily achievement is available.</summary>
    [JsonPropertyName("max")]
    public required int Max { get; init; }
}

/// <summary>Represents an expansion access requirement for a <see cref="DailyAchievement"/>.</summary>
public record DailyRequiredAccess
{
    /// <summary>Game expansion product required (e.g., "HeartOfThorns", "PathOfFire", "EndOfDragons").</summary>
    [JsonPropertyName("product")]
    public required string Product { get; init; }

    /// <summary>Access condition: "HasAccess" means the product must be owned; "NoAccess" means it must not be owned.</summary>
    [JsonPropertyName("condition")]
    public required string Condition { get; init; }
}
