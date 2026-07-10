using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Backstory;

/// <summary>Represents a backstory question presented during Guild Wars 2 character creation.</summary>
public record BackstoryQuestion
{
    /// <summary>Unique question ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display title of the question as shown during character creation.</summary>
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>Descriptive flavor text accompanying the question.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>Backstory answer IDs available for this question; each resolvable to a <see cref="BackstoryAnswer"/>.</summary>
    [JsonPropertyName("answers")]
    public string[] Answers { get; init; } = [];

    /// <summary>Display order of this question relative to others during character creation; lower values appear earlier.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>Race names this question applies to (e.g., "Human", "Norn"); empty if applicable to all races.</summary>
    [JsonPropertyName("races")]
    public string[] Races { get; init; } = [];

    /// <summary>Profession names this question applies to (e.g., "Guardian", "Warrior"); empty if applicable to all professions.</summary>
    [JsonPropertyName("professions")]
    public string[] Professions { get; init; } = [];
}
