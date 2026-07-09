using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a ranked PvP league season, including its division structure, rank definitions, and leaderboard configuration.</summary>
public record PvpSeason
{
    /// <summary>Unique season ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the season.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>ISO 8601 date string for when the season begins.</summary>
    [JsonPropertyName("start")]
    public required string Start { get; init; }

    /// <summary>ISO 8601 date string for when the season ends.</summary>
    [JsonPropertyName("end")]
    public required string End { get; init; }

    /// <summary>True if the season is currently active.</summary>
    [JsonPropertyName("active")]
    public required bool Active { get; init; }

    /// <summary>Ordered list of divisions in this season.</summary>
    [JsonPropertyName("divisions")]
    public PvpSeasonDivision[] Divisions { get; init; } = [];

    /// <summary>Rank definitions used for this season's leaderboard display.</summary>
    [JsonPropertyName("ranks")]
    public PvpSeasonRank[] Ranks { get; init; } = [];

    /// <summary>Leaderboard configurations for this season.</summary>
    [JsonPropertyName("leaderboards")]
    public PvpSeasonLeaderboard[] Leaderboards { get; init; } = [];
}

/// <summary>Represents a single division within a <see cref="PvpSeason"/>, containing tiers that players progress through.</summary>
public record PvpSeasonDivision
{
    /// <summary>Display name of this division (e.g., "Amber", "Legendary").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Behavior flags for this division (e.g., "Repeatable", "CanLosePoints").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>URL to the large division icon image.</summary>
    [JsonPropertyName("large_icon")]
    public required string LargeIcon { get; init; }

    /// <summary>URL to the small division icon image.</summary>
    [JsonPropertyName("small_icon")]
    public required string SmallIcon { get; init; }

    /// <summary>URL to the pip (progress point) icon image for this division.</summary>
    [JsonPropertyName("pip_icon")]
    public required string PipIcon { get; init; }

    /// <summary>Ordered list of tiers within this division.</summary>
    [JsonPropertyName("tiers")]
    public PvpDivisionTier[] Tiers { get; init; } = [];
}

/// <summary>Represents a single tier within a <see cref="PvpSeasonDivision"/>.</summary>
public record PvpDivisionTier
{
    /// <summary>Number of pips required to fill and complete this tier.</summary>
    [JsonPropertyName("points")]
    public required int Points { get; init; }
}

/// <summary>Represents a leaderboard rank display entry within a <see cref="PvpSeason"/>.</summary>
public record PvpSeasonRank
{
    /// <summary>Display name of this rank (e.g., "Bronze", "Platinum").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of this rank.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the rank's full icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>URL to the rank's overlay image.</summary>
    [JsonPropertyName("overlay")]
    public required string Overlay { get; init; }

    /// <summary>URL to the rank's small overlay image.</summary>
    [JsonPropertyName("overlay_small")]
    public required string OverlaySmall { get; init; }

    /// <summary>Ordered list of rating thresholds defining sub-ranks within this rank.</summary>
    [JsonPropertyName("tiers")]
    public PvpRankTier[] Tiers { get; init; } = [];
}

/// <summary>Represents a rating threshold tier within a <see cref="PvpSeasonRank"/>.</summary>
public record PvpRankTier
{
    /// <summary>Minimum rating score required to reach this rank tier.</summary>
    [JsonPropertyName("rating")]
    public required int Rating { get; init; }
}

/// <summary>Represents the leaderboard configurations available for a <see cref="PvpSeason"/>.</summary>
public record PvpSeasonLeaderboard
{
    /// <summary>Configuration for the individual player ladder leaderboard; null if not present for this season.</summary>
    [JsonPropertyName("ladder")]
    public PvpLeaderboardEntry? Ladder { get; init; }

    /// <summary>Configuration for the guild leaderboard; null if not present for this season.</summary>
    [JsonPropertyName("guild")]
    public PvpLeaderboardEntry? Guild { get; init; }

    /// <summary>Configuration for the legendary division leaderboard; null if not present for this season.</summary>
    [JsonPropertyName("legendary")]
    public PvpLeaderboardEntry? Legendary { get; init; }
}

/// <summary>Represents a single leaderboard type configuration within a <see cref="PvpSeasonLeaderboard"/>.</summary>
public record PvpLeaderboardEntry
{
    /// <summary>Configuration settings for this leaderboard.</summary>
    [JsonPropertyName("settings")]
    public required PvpLeaderboardSettings Settings { get; init; }

    /// <summary>Scoring method definition for this leaderboard.</summary>
    [JsonPropertyName("scorings")]
    public required PvpLeaderboardScorings Scorings { get; init; }
}

/// <summary>Represents configuration settings for a <see cref="PvpLeaderboardEntry"/>.</summary>
public record PvpLeaderboardSettings
{
    /// <summary>Name identifier for this settings configuration.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Duration of the leaderboard window; null if there is no time limit.</summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; init; }

    /// <summary>Identifier of the scoring method used; matches a <see cref="PvpLeaderboardScorings"/> ID.</summary>
    [JsonPropertyName("scoring")]
    public required string Scoring { get; init; }

    /// <summary>Ordered list of tier display configurations.</summary>
    [JsonPropertyName("tiers")]
    public PvpSettingsTier[] Tiers { get; init; } = [];
}

/// <summary>Represents a single display tier within <see cref="PvpLeaderboardSettings"/>.</summary>
public record PvpSettingsTier
{
    /// <summary>Color code (e.g., hex string) associated with this tier's display.</summary>
    [JsonPropertyName("color")]
    public required string Color { get; init; }

    /// <summary>Tier classification type.</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Display name for this tier (e.g., "Gold", "Silver").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Two-element array [min, max] defining the rating range for this tier.</summary>
    [JsonPropertyName("range")]
    public int[] Range { get; init; } = [];
}

/// <summary>Represents the scoring method definition for a <see cref="PvpLeaderboardEntry"/>.</summary>
public record PvpLeaderboardScorings
{
    /// <summary>Unique scoring method identifier.</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Type of scoring (e.g., "Integer").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Description of how this scoring method works.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Display name of this scoring method.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Sort order direction (e.g., "MoreIsBetter").</summary>
    [JsonPropertyName("ordering")]
    public required string Ordering { get; init; }
}
