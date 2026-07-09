using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a mount type in GW2, including its available skins and skills.</summary>
public record MountType
{
    /// <summary>Unique mount type identifier string (e.g., "raptor", "springer", "skimmer").</summary>
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    /// <summary>Display name of the mount type.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Default skin ID for this mount; resolvable to a <see cref="MountSkin"/>.</summary>
    [JsonPropertyName("default_skin")]
    public required int DefaultSkin { get; init; }

    /// <summary>List of all skin IDs available for this mount type; each resolvable to a <see cref="MountSkin"/>.</summary>
    [JsonPropertyName("skins")]
    public int[] Skins { get; init; } = [];

    /// <summary>List of skills available on this mount; see <see cref="MountSkill"/>.</summary>
    [JsonPropertyName("skills")]
    public MountSkill[] Skills { get; init; } = [];

    /// <summary>Internal GUID for the mount type.</summary>
    [JsonPropertyName("guid")]
    public string? Guid { get; init; } = null;
}

/// <summary>Represents a skill slot on a <see cref="MountType"/>.</summary>
public record MountSkill
{
    /// <summary>Skill ID of the mount ability; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Slot identifier for this skill (e.g., "Weapon_1", "Profession_1").</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }
}
