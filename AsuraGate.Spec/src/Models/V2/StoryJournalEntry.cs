using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a single story step (journal entry) within a GW2 story chapter.</summary>
public record StoryJournalEntry
{
    /// <summary>Unique story step ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of this story step.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Character level recommended for this story step.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>ID of the parent story this step belongs to; resolvable via API:2/stories.</summary>
    [JsonPropertyName("story")]
    public required int Story { get; init; }

    /// <summary>List of objectives that must be completed in this story step; see <see cref="StoryGoal"/>.</summary>
    [JsonPropertyName("goals")]
    public StoryGoal[] Goals { get; init; } = [];
}

/// <summary>Represents a single objective within a <see cref="StoryJournalEntry"/> story step.</summary>
public record StoryGoal
{
    /// <summary>Objective description text shown while the objective is in progress.</summary>
    [JsonPropertyName("active")]
    public required string Active { get; init; }

    /// <summary>Objective description text shown after the objective is completed.</summary>
    [JsonPropertyName("complete")]
    public required string Complete { get; init; }
}
