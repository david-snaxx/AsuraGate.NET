using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the backstory choices made for a character.</summary>
public record CharacterBackstory
{
    /// <summary>Backstory answer IDs selected for this character; each resolvable to a <see cref="BackstoryAnswer"/>.</summary>
    [JsonPropertyName("backstory")]
    public string[] Ids { get; init; } = [];
}
