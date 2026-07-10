using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Characters;

/// <summary>Represents the crafting recipes unlocked by a character.</summary>
public record CharacterRecipes
{
    /// <summary>Unlocked recipe IDs for this character; each resolvable to a <see cref="Recipe"/>.</summary>
    [JsonPropertyName("recipes")]
    public int[] Ids { get; init; } = [];
}
