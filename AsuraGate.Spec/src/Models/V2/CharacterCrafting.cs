using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the crafting disciplines known by a character.</summary>
public record CharacterCrafting
{
    /// <summary>Crafting discipline entries for this character.</summary>
    [JsonPropertyName("crafting")]
    public CraftingDiscipline[] Crafting { get; init; } = [];
}

/// <summary>Represents a single crafting discipline known by a character within <see cref="CharacterCrafting"/>.</summary>
public record CraftingDiscipline
{
    /// <summary>Name of the crafting discipline (e.g., "Armorsmith", "Chef", "Jeweler", "Tailor").</summary>
    [JsonPropertyName("discipline")]
    public required string Discipline { get; init; }

    /// <summary>Current crafting skill rating within this discipline (0–500).</summary>
    [JsonPropertyName("rating")]
    public required int Rating { get; init; }

    /// <summary>Whether this discipline is currently active on the character; characters can only have two disciplines active at a time.</summary>
    [JsonPropertyName("active")]
    public required bool Active { get; init; }
}
