using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a World vs. World ability that players can train by spending WvW rank points.</summary>
public record WvwAbility
{
    /// <summary>Unique ability ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the ability.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the ability's effect.</summary>
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    /// <summary>URL to the ability's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Ordered list of rank levels for this ability, each adding improved effects.</summary>
    [JsonPropertyName("ranks")]
    public WvwAbilityRank[] Ranks { get; init; } = [];
}

/// <summary>Represents a single trainable rank level within a <see cref="WvwAbility"/>.</summary>
public record WvwAbilityRank
{
    /// <summary>WvW rank points required to train this rank level.</summary>
    [JsonPropertyName("cost")]
    public required int Cost { get; init; }

    /// <summary>Description of the effect granted at this rank level.</summary>
    [JsonPropertyName("effect")]
    public required string Effect { get; init; }
}
