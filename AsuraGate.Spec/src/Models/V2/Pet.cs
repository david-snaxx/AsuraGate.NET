using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a ranger pet that can be charmed in the wild and used in combat.</summary>
public record Pet
{
    /// <summary>Unique pet ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of this pet.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Flavor text description of the pet.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the pet's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>List of skills available to this pet; see <see cref="PetSkill"/>.</summary>
    [JsonPropertyName("skills")]
    public PetSkill[] Skills { get; init; } = [];
}

/// <summary>Represents a single skill available to a <see cref="Pet"/>.</summary>
public record PetSkill
{
    /// <summary>Skill ID; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }
}
