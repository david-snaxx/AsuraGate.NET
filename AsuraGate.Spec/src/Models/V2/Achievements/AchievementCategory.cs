using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Achievements;

/// <summary>Represents a grouping category of achievements within an achievement group.</summary>
public record AchievementCategory
{
    /// <summary>Unique category ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the category (e.g., "Slayer", "Explorer").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the category's theme or goal.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Display order index used to sort this category within its group.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>URL to the category's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Achievement IDs available in this category.</summary>
    [JsonPropertyName("achievements")]
    public CategoryAchievement[] Achievements { get; init; } = [];

    /// <summary>Achievement IDs that will be available in this category tomorrow (daily rotation).</summary>
    [JsonPropertyName("tomorrow")]
    public CategoryAchievement[] Tomorrow { get; init; } = [];
}

public record CategoryAchievement
{
    /// <summary>The ID of the achievement.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Describes if a daily requires a specific campaign.</summary>
    [JsonPropertyName("required_access")]
    public AchievementAccess? RequiredAccess { get; init; }

    /// <summary>The type of daily achievement (e.g., "PvE", "PvP", "WvW").</summary>
    [JsonPropertyName("flags")]
    public string[]? Flags { get; init; }

    /// <summary>The inclusive level range for this achievement.</summary>
    [JsonPropertyName("level")]
    public int[]? Level { get; init; }
}

public record AchievementAccess
{
    [JsonPropertyName("product")]
    public string Product { get; init; } = string.Empty;

    [JsonPropertyName("condition")]
    public string Condition { get; init; } = string.Empty;
}