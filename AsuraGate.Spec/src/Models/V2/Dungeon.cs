using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a dungeon and its available story and explorable paths.</summary>
public record Dungeon
{
    /// <summary>Unique dungeon ID string (e.g., "ascalonian_catacombs").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>List of available paths in this dungeon; see <see cref="DungeonPath"/>.</summary>
    [JsonPropertyName("paths")]
    public DungeonPath[] Paths { get; init; } = [];
}

/// <summary>Represents a single path within a <see cref="Dungeon"/>.</summary>
public record DungeonPath
{
    /// <summary>Unique path ID string (e.g., "ac_story", "ac_explorable0").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Path mode type: "Story" for the story mode path, or "Explorable" for explorable mode paths.</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
