using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a dye color that can be applied to armor and cosmetics through the dye panel.</summary>
public record Dye
{
    /// <summary>Unique dye ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the dye.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Base RGB values before material modifiers are applied [R, G, B].</summary>
    [JsonPropertyName("base_rgb")]
    public int[] BaseRgb { get; init; } = [];

    /// <summary>Color appearance on cloth material; see <see cref="ColorDetail"/>.</summary>
    [JsonPropertyName("cloth")]
    public required ColorDetail Cloth { get; init; }

    /// <summary>Color appearance on leather material; see <see cref="ColorDetail"/>.</summary>
    [JsonPropertyName("leather")]
    public required ColorDetail Leather { get; init; }

    /// <summary>Color appearance on metal material; see <see cref="ColorDetail"/>.</summary>
    [JsonPropertyName("metal")]
    public required ColorDetail Metal { get; init; }

    /// <summary>Color appearance on fur material; null if the dye has no fur variant; see <see cref="ColorDetail"/>.</summary>
    [JsonPropertyName("fur")]
    public ColorDetail? Fur { get; init; }

    /// <summary>ID of the dye item that unlocks this color; resolvable to an <see cref="Item"/>; null if not unlocked via an item.</summary>
    [JsonPropertyName("item")]
    public int? Item { get; init; }

    /// <summary>List of category labels for this dye (e.g., "Blues", "Vibrant", "Pastel").</summary>
    [JsonPropertyName("categories")]
    public string[] Categories { get; init; } = [];
}

/// <summary>Represents the visual appearance of a <see cref="Dye"/> on a specific material type.</summary>
public record ColorDetail
{
    /// <summary>Brightness adjustment applied to the base color (-255 to 255).</summary>
    [JsonPropertyName("brightness")]
    public required int Brightness { get; init; }

    /// <summary>Contrast multiplier applied to the base color.</summary>
    [JsonPropertyName("contrast")]
    public required double Contrast { get; init; }

    /// <summary>Hue rotation in degrees (0–360).</summary>
    [JsonPropertyName("hue")]
    public required int Hue { get; init; }

    /// <summary>Saturation multiplier applied to the base color.</summary>
    [JsonPropertyName("saturation")]
    public required double Saturation { get; init; }

    /// <summary>Lightness multiplier applied to the base color.</summary>
    [JsonPropertyName("lightness")]
    public required double Lightness { get; init; }

    /// <summary>Resulting RGB values after all adjustments are applied [R, G, B].</summary>
    [JsonPropertyName("rgb")]
    public int[] Rgb { get; init; } = [];
}
