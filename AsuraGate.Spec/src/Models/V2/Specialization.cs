using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a specialization (core or elite) available to a profession.</summary>
public record Specialization
{
    /// <summary>Unique specialization ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the specialization.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Profession identifier this specialization belongs to (e.g., "Guardian", "Warrior").</summary>
    [JsonPropertyName("profession")]
    public required string Profession { get; init; }

    /// <summary>Whether this is an elite specialization.</summary>
    [JsonPropertyName("elite")]
    public required bool Elite { get; init; }

    /// <summary>URL to the specialization icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>URL to the small profession icon shown when this specialization is active.</summary>
    [JsonPropertyName("profession_icon")]
    public string? ProfessionIcon { get; init; } = null;

    /// <summary>URL to the large profession icon shown when this specialization is active.</summary>
    [JsonPropertyName("profession_icon_big")]
    public string? ProfessionIconBig { get; init; } = null;

    /// <summary>URL to the specialization background image.</summary>
    [JsonPropertyName("background")]
    public required string Background { get; init; }

    /// <summary>List of minor trait IDs (fixed slots, not player-selectable); each resolvable to a <see cref="Trait"/>.</summary>
    [JsonPropertyName("minor_traits")]
    public int[] MinorTraits { get; init; } = [];

    /// <summary>List of major trait IDs (player-selectable); each resolvable to a <see cref="Trait"/>.</summary>
    [JsonPropertyName("major_traits")]
    public int[] MajorTraits { get; init; } = [];

    /// <summary>Trait ID of the weapon trait for elite specializations; resolvable to a <see cref="Trait"/>; null for core specializations.</summary>
    [JsonPropertyName("weapon_trait")]
    public int? WeaponTrait { get; init; }
}
