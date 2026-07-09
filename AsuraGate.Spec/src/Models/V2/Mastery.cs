using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a mastery track that unlocks passive account-wide abilities through experience investment.</summary>
public record Mastery
{
    /// <summary>Unique mastery ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the mastery track.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Prerequisite description for unlocking this mastery track.</summary>
    [JsonPropertyName("requirement")]
    public required string Requirement { get; init; }

    /// <summary>Display order in the mastery UI.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>URL to the background image for this mastery track.</summary>
    [JsonPropertyName("background")]
    public required string Background { get; init; }

    /// <summary>Mastery region this track belongs to (e.g., "Maguuma", "CentralTyria", "Desert").</summary>
    [JsonPropertyName("region")]
    public required string Region { get; init; }

    /// <summary>Ordered list of mastery levels with their unlock details; see <see cref="MasteryLevel"/>.</summary>
    [JsonPropertyName("levels")]
    public MasteryLevel[] Levels { get; init; } = [];
}

/// <summary>Represents a single level within a <see cref="Mastery"/> track.</summary>
public record MasteryLevel
{
    /// <summary>Display name of this mastery level.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the passive ability unlocked at this level.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Training hint shown in the mastery UI.</summary>
    [JsonPropertyName("instruction")]
    public required string Instruction { get; init; }

    /// <summary>URL to the icon for this mastery level.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Number of mastery points required to unlock this level.</summary>
    [JsonPropertyName("point_cost")]
    public required int PointCost { get; init; }

    /// <summary>Amount of experience required to complete training at this level.</summary>
    [JsonPropertyName("exp_cost")]
    public required int ExpCost { get; init; }
}
