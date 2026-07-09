using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents the specialization loadouts across all game modes for a character.</summary>
public record CharacterSpecializations
{
    /// <summary>Per-mode specialization loadout container.</summary>
    [JsonPropertyName("specializations")]
    public required SpecializationsByMode Specializations { get; init; }
}

/// <summary>Contains the per-game-mode specialization slot assignments for a character within <see cref="CharacterSpecializations"/>.</summary>
public record SpecializationsByMode
{
    /// <summary>Three specialization slots used in PvE.</summary>
    [JsonPropertyName("pve")]
    public SpecializationSlot[] Pve { get; init; } = [];

    /// <summary>Three specialization slots used in PvP.</summary>
    [JsonPropertyName("pvp")]
    public SpecializationSlot[] Pvp { get; init; } = [];

    /// <summary>Three specialization slots used in WvW.</summary>
    [JsonPropertyName("wvw")]
    public SpecializationSlot[] Wvw { get; init; } = [];
}

/// <summary>Represents a single specialization slot and its selected traits within <see cref="SpecializationsByMode"/>.</summary>
public record SpecializationSlot
{
    /// <summary>Specialization ID slotted in this position; resolvable to a <see cref="Specialization"/>; null if the slot is empty.</summary>
    [JsonPropertyName("id")]
    public int? Id { get; init; }

    /// <summary>Up to three selected trait IDs within this specialization; each resolvable to a <see cref="Trait"/>; null entries indicate an unselected trait slot.</summary>
    [JsonPropertyName("traits")]
    public int[]? Traits { get; init; }
}
