using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a story instance within the game's personal story or Living World narrative.</summary>
public record Story
{
    /// <summary>Unique story ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Season ID (UUID string) that this story belongs to.</summary>
    [JsonPropertyName("season")]
    public required string Season { get; init; }

    /// <summary>Display name of this story.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the story's narrative.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>In-universe timeline label indicating when this story takes place (e.g., "After the personal story").</summary>
    [JsonPropertyName("timeline")]
    public required string Timeline { get; init; }

    /// <summary>Recommended character level for this story.</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>Display order of this story within its season (lower = earlier).</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>Ordered list of chapters that make up this story; see <see cref="StoryChapter"/>.</summary>
    [JsonPropertyName("chapters")]
    public StoryChapter[] Chapters { get; init; } = [];

    /// <summary>List of race names this story is available to (e.g., "Human", "Sylvari"); empty list means available to all races.</summary>
    [JsonPropertyName("races")]
    public string[] Races { get; init; } = [];

    /// <summary>List of story flags (e.g., "RequiresUnlock").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];
}

/// <summary>Represents a single named chapter within a <see cref="Story"/>.</summary>
public record StoryChapter
{
    /// <summary>Display name of this chapter.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}
