using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Achievements;

/// <summary>Represents a top-level achievement group that organizes achievement categories (e.g., "Heart of Thorns", "General").</summary>
public record AchievementGroup
{
    /// <summary>Unique group ID (UUID string).</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the group.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the group's overall theme.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Display order index used to sort this group in the achievement panel.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>Achievement category IDs belonging to this group; each resolvable to an <see cref="AchievementCategory"/>.</summary>
    [JsonPropertyName("categories")]
    public int[] Categories { get; init; } = [];
}
