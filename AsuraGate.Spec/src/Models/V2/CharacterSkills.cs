using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents the skill loadouts across all game modes for a character.</summary>
public record CharacterSkills
{
    /// <summary>Per-mode skill loadout container.</summary>
    [JsonPropertyName("skills")]
    public required SkillsByMode Skills { get; init; }
}

/// <summary>Contains the per-game-mode skill loadouts for a character within <see cref="CharacterSkills"/>.</summary>
public record SkillsByMode
{
    /// <summary>Skill loadout used in PvE (open world, story, fractals, raids).</summary>
    [JsonPropertyName("pve")]
    public required SkillLoadout Pve { get; init; }

    /// <summary>Skill loadout used in PvP (Structured PvP arenas).</summary>
    [JsonPropertyName("pvp")]
    public required SkillLoadout Pvp { get; init; }

    /// <summary>Skill loadout used in WvW (World vs. World).</summary>
    [JsonPropertyName("wvw")]
    public required SkillLoadout Wvw { get; init; }
}

/// <summary>Represents the skill bar loadout for a single game mode within <see cref="SkillsByMode"/>.</summary>
public record SkillLoadout
{
    /// <summary>Skill ID in the heal slot; resolvable to a <see cref="Skill"/>; null if empty.</summary>
    [JsonPropertyName("heal")]
    public int? Heal { get; init; }

    /// <summary>Up to three utility skill IDs; each resolvable to a <see cref="Skill"/>; null entries indicate an empty slot.</summary>
    [JsonPropertyName("utilities")]
    public int[]? Utilities { get; init; }

    /// <summary>Skill ID in the elite slot; resolvable to a <see cref="Skill"/>; null if empty.</summary>
    [JsonPropertyName("elite")]
    public int? Elite { get; init; }

    /// <summary>Active Revenant legend IDs for this mode (Revenant only); each resolvable to a <see cref="Legend"/>; null for other professions.</summary>
    [JsonPropertyName("legends")]
    public string[]? Legends { get; init; }
}
