using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a named stat set (attribute combination) that can be applied to equipment.</summary>
public record ItemStat
{
    /// <summary>Unique stat set ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the stat set (e.g., "Berserker's", "Viper's").</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>List of attribute bonuses provided by this stat set; see <see cref="StatAttribute"/>.</summary>
    [JsonPropertyName("attributes")]
    public StatAttribute[] Attributes { get; init; } = [];
}

/// <summary>Represents a single attribute contribution within an <see cref="ItemStat"/> stat set.</summary>
public record StatAttribute
{
    /// <summary>Attribute name (e.g., "Power", "Precision", "Ferocity").</summary>
    [JsonPropertyName("attribute")]
    public required string Attribute { get; init; }

    /// <summary>Multiplier applied to the item's attribute adjustment value to compute the final bonus.</summary>
    [JsonPropertyName("multiplier")]
    public required double Multiplier { get; init; }

    /// <summary>Fixed bonus added to this attribute, independent of item level.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}
