using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a playable profession (class) in GW2, including its skills, specializations, and weapons.</summary>
public record Profession
{
    /// <summary>Unique profession identifier string (e.g., "Guardian", "Mesmer", "Revenant").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the profession.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Profession template code integer used in build templates; null for some professions.</summary>
    [JsonPropertyName("code")]
    public int? Code { get; init; }

    /// <summary>URL to the profession's small icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>URL to the profession's large icon.</summary>
    [JsonPropertyName("icon_big")]
    public required string IconBig { get; init; }

    /// <summary>List of specialization IDs available to this profession; each resolvable to a <see cref="Specialization"/>.</summary>
    [JsonPropertyName("specializations")]
    public int[] Specializations { get; init; } = [];

    /// <summary>List of hero point training tracks for this profession; see <see cref="ProfessionTraining"/>.</summary>
    [JsonPropertyName("training")]
    public ProfessionTraining[] Training { get; init; } = [];

    /// <summary>Map of weapon type name to slot and skill details; see <see cref="WeaponDetails"/>.</summary>
    [JsonPropertyName("weapons")]
    public Dictionary<string, WeaponDetails> Weapons { get; init; } = [];

    /// <summary>List of profession behavior flags.</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of all skills associated with this profession; see <see cref="ProfessionSkill"/>.</summary>
    [JsonPropertyName("skills")]
    public ProfessionSkill[] Skills { get; init; } = [];

    /// <summary>List of [palette_id, skill_id] pairs mapping the in-game skill palette.</summary>
    [JsonPropertyName("skills_by_palette")]
    public int[][] SkillsByPalette { get; init; } = [];
}

/// <summary>Represents a hero point training track for a <see cref="Profession"/>.</summary>
public record ProfessionTraining
{
    /// <summary>Unique training track ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Training category (e.g., "Skills", "Specializations").</summary>
    [JsonPropertyName("category")]
    public required string Category { get; init; }

    /// <summary>Display name of the training track.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Ordered list of training nodes in this track; see <see cref="TrackEntry"/>.</summary>
    [JsonPropertyName("track")]
    public TrackEntry[] Track { get; init; } = [];
}

/// <summary>Represents a single node in a <see cref="ProfessionTraining"/> track.</summary>
public record TrackEntry
{
    /// <summary>Hero point cost of this training node.</summary>
    [JsonPropertyName("cost")]
    public required int Cost { get; init; }

    /// <summary>Node type: "Skill" or "Trait".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Skill ID unlocked by this node when type is "Skill"; resolvable to a <see cref="Skill"/>; null for trait nodes.</summary>
    [JsonPropertyName("skill_id")]
    public int? SkillId { get; init; }

    /// <summary>Trait ID unlocked by this node when type is "Trait"; resolvable to a <see cref="Trait"/>; null for skill nodes.</summary>
    [JsonPropertyName("trait_id")]
    public int? TraitId { get; init; }
}

/// <summary>Represents the slot and skill details for a weapon type available to a <see cref="Profession"/>.</summary>
public record WeaponDetails
{
    /// <summary>Specialization ID required to wield this weapon (elite specialization weapons); resolvable to a <see cref="Specialization"/>; null for base profession weapons.</summary>
    [JsonPropertyName("specialization")]
    public int? Specialization { get; init; }

    /// <summary>List of weapon flags (e.g., "Mainhand", "Offhand", "TwoHand").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of skills available on this weapon; see <see cref="WeaponSkill"/>.</summary>
    [JsonPropertyName("skills")]
    public WeaponSkill[] Skills { get; init; } = [];
}

/// <summary>Represents a single skill on a weapon within <see cref="WeaponDetails"/>.</summary>
public record WeaponSkill
{
    /// <summary>Skill ID; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Skill bar slot (e.g., "Weapon_1", "Weapon_2", "Weapon_3").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>Off-hand weapon type required to enable this skill (dual-wield skills); null otherwise.</summary>
    [JsonPropertyName("offhand")]
    public string? Offhand { get; init; }

    /// <summary>Elementalist attunement required for this skill (e.g., "Fire", "Water"); null for non-elementalist skills.</summary>
    [JsonPropertyName("attunement")]
    public string? Attunement { get; init; }

    /// <summary>Source profession identifier if this skill is borrowed from another profession; null otherwise.</summary>
    [JsonPropertyName("source")]
    public string? Source { get; init; }
}

/// <summary>Represents an entry in the full skill list for a <see cref="Profession"/>.</summary>
public record ProfessionSkill
{
    /// <summary>Skill ID; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Skill bar slot type (e.g., "Heal", "Utility", "Elite", "Profession_1").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>Skill type category (e.g., "Weapon", "Heal", "Utility", "Elite").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Source profession if this skill is borrowed; null otherwise.</summary>
    [JsonPropertyName("source")]
    public string? Source { get; init; }
}
