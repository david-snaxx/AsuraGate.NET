using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a single selectable answer for a character creation backstory question.</summary>
public record BackstoryAnswer
{
    /// <summary>Unique answer ID string (e.g., "7-54").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display title of this answer as shown during character creation.</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Descriptive text explaining what choosing this answer means for the character.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>In-game journal entry text unlocked when this answer is chosen.</summary>
    [JsonPropertyName("journal")]
    public required string Journal { get; init; }

    /// <summary>ID of the backstory question this answer belongs to; resolvable to a <see cref="BackstoryQuestion"/>.</summary>
    [JsonPropertyName("question")]
    public required int Question { get; init; }

    /// <summary>Profession names this answer is available to; empty if available to all professions.</summary>
    [JsonPropertyName("professions")]
    public string[] Professions { get; init; } = [];

    /// <summary>Race names this answer is available to; empty if available to all races.</summary>
    [JsonPropertyName("races")]
    public string[] Races { get; init; } = [];
}
