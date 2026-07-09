using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a build template saved in the authenticated account's build storage.</summary>
public record AccountBuildStorageTemplate
{
    /// <summary>Display name given to this saved build template.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Profession this build is configured for (e.g., "Guardian", "Mesmer", "Revenant").</summary>
    [JsonPropertyName("profession")]
    public required string Profession { get; init; }

    /// <summary>The three specialization slots in this build.</summary>
    [JsonPropertyName("specializations")]
    public BuildStorageSpecialization[] Specializations { get; init; } = [];

    /// <summary>Land skill loadout for this build.</summary>
    [JsonPropertyName("skills")]
    public required BuildStorageSkills Skills { get; init; }

    /// <summary>Aquatic skill loadout for this build.</summary>
    [JsonPropertyName("aquatic_skills")]
    public required BuildStorageSkills AquaticSkills { get; init; }

    /// <summary>Two Revenant legend IDs for land combat (Revenant only); null for other professions.</summary>
    [JsonPropertyName("legends")]
    public string[]? Legends { get; init; }

    /// <summary>Two Revenant legend IDs for aquatic combat (Revenant only); null for other professions.</summary>
    [JsonPropertyName("aquatic_legends")]
    public string[]? AquaticLegends { get; init; }
}

/// <summary>Represents a single specialization slot in an <see cref="AccountBuildStorageTemplate"/>.</summary>
public record BuildStorageSpecialization
{
    /// <summary>Specialization ID slotted in this position; resolvable to a <see cref="Specialization"/>; null if the slot is empty.</summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>Up to three trait IDs selected within this specialization; each resolvable to a <see cref="Trait"/>; null entries indicate an unselected trait slot.</summary>
    [JsonPropertyName("traits")]
    public int[]? Traits { get; init; }
}

/// <summary>Represents the skill loadout within an <see cref="AccountBuildStorageTemplate"/>.</summary>
public record BuildStorageSkills
{
    /// <summary>Skill ID in the heal slot; resolvable to a <see cref="Skill"/>; null if the slot is empty.</summary>
    [JsonPropertyName("heal")]
    public int? Heal { get; init; }

    /// <summary>Up to three utility skill IDs; each resolvable to a <see cref="Skill"/>; null entries indicate an empty slot.</summary>
    [JsonPropertyName("utilities")]
    public int[]? Utilities { get; init; }

    /// <summary>Skill ID in the elite slot; resolvable to a <see cref="Skill"/>; null if the slot is empty.</summary>
    [JsonPropertyName("elite")]
    public int? Elite { get; init; }
}
