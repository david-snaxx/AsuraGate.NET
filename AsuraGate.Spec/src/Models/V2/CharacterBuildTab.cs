using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a saved build tab (build template slot) for a character.</summary>
public record CharacterBuildTab
{
    /// <summary>One-based index of this build tab.</summary>
    [JsonPropertyName("tab")]
    public required int Tab { get; init; }

    /// <summary>Whether this tab is the currently active build loadout.</summary>
    [JsonPropertyName("is_active")]
    public required bool IsActive { get; init; }

    /// <summary>The build configuration stored in this tab.</summary>
    [JsonPropertyName("build")]
    public required CharacterBuild Build { get; init; }
}

/// <summary>Represents the full build configuration stored in a <see cref="CharacterBuildTab"/>.</summary>
public record CharacterBuild
{
    /// <summary>Display name given to this build.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Profession this build is configured for (e.g., "Guardian", "Ranger", "Revenant").</summary>
    [JsonPropertyName("profession")]
    public required string Profession { get; init; }

    /// <summary>The three specialization slots in this build.</summary>
    [JsonPropertyName("specializations")]
    public CharacterBuildSpecialization[] Specializations { get; init; } = [];

    /// <summary>Land skill loadout for this build.</summary>
    [JsonPropertyName("skills")]
    public required CharacterBuildSkills Skills { get; init; }

    /// <summary>Aquatic skill loadout for this build.</summary>
    [JsonPropertyName("aquatic_skills")]
    public required CharacterBuildSkills AquaticSkills { get; init; }

    /// <summary>Two Revenant legend IDs for land combat (Revenant only); null for other professions.</summary>
    [JsonPropertyName("legends")]
    public string[]? Legends { get; init; }

    /// <summary>Two Revenant legend IDs for aquatic combat (Revenant only); null for other professions.</summary>
    [JsonPropertyName("aquatic_legends")]
    public string[]? AquaticLegends { get; init; }

    /// <summary>Ranger pet selections for this build (Ranger only); null for other professions.</summary>
    [JsonPropertyName("pets")]
    public CharacterBuildPets? Pets { get; init; }
}

/// <summary>Represents a single specialization slot in a <see cref="CharacterBuild"/>.</summary>
public record CharacterBuildSpecialization
{
    /// <summary>Specialization ID slotted in this position; resolvable to a <see cref="Specialization"/>; null if the slot is empty.</summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>Up to three trait IDs selected within this specialization; each resolvable to a <see cref="Trait"/>; null entries indicate an unselected trait slot.</summary>
    [JsonPropertyName("traits")]
    public int[]? Traits { get; init; }
}

/// <summary>Represents the skill bar loadout in a <see cref="CharacterBuild"/>.</summary>
public record CharacterBuildSkills
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
}

/// <summary>Represents the Ranger pet selections in a <see cref="CharacterBuild"/>.</summary>
public record CharacterBuildPets
{
    /// <summary>Up to two pet IDs selected for land combat; each resolvable to a <see cref="Pet"/>.</summary>
    [JsonPropertyName("terrestrial")]
    public int[]? Terrestrial { get; init; }

    /// <summary>Up to two pet IDs selected for aquatic combat; each resolvable to a <see cref="Pet"/>.</summary>
    [JsonPropertyName("aquatic")]
    public int[]? Aquatic { get; init; }
}
