using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the core biographical and progression data for a Guild Wars 2 character.</summary>
public record CharacterCore
{
    /// <summary>Display name of the character.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Playable race of the character (e.g., "Asura", "Charr", "Human", "Norn", "Sylvari").</summary>
    [JsonPropertyName("race")]
    public required string Race { get; init; }

    /// <summary>Gender of the character: "Male" or "Female".</summary>
    [JsonPropertyName("gender")]
    public required string Gender { get; init; }

    /// <summary>Profession (class) of the character (e.g., "Guardian", "Mesmer", "Revenant").</summary>
    [JsonPropertyName("profession")]
    public required string Profession { get; init; }

    /// <summary>Current character level (1–80).</summary>
    [JsonPropertyName("level")]
    public required int Level { get; init; }

    /// <summary>ID of the guild this character is representing; null if no guild is active.</summary>
    [JsonPropertyName("guild")]
    public string? Guild { get; init; }

    /// <summary>Total time this character has been played, in seconds.</summary>
    [JsonPropertyName("age")]
    public required int Age { get; init; }

    /// <summary>Timestamp of when this character was created.</summary>
    [JsonPropertyName("created")]
    public required DateTime Created { get; init; }

    /// <summary>Timestamp of the most recent modification to this character.</summary>
    [JsonPropertyName("last_modified")]
    public required DateTime LastModified { get; init; }

    /// <summary>Total number of times this character has been defeated.</summary>
    [JsonPropertyName("deaths")]
    public required int Deaths { get; init; }

    /// <summary>ID of the title currently equipped on this character; resolvable to a <see cref="Model.Title"/>; null if no title is selected.</summary>
    [JsonPropertyName("title")]
    public int? Title { get; init; }
}
