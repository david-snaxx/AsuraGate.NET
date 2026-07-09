using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a skiff skin, a cosmetic customization for the Skiff mount introduced in the End of Dragons expansion.</summary>
public record Skiff
{
    /// <summary>Unique skiff skin ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of this skiff skin.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the skin's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>List of dye slots available on this skiff skin for color customization; see <see cref="SkiffDyeSlot"/>.</summary>
    [JsonPropertyName("dye_slots")]
    public SkiffDyeSlot[] DyeSlots { get; init; } = [];
}

/// <summary>Represents a single dye slot on a <see cref="Skiff"/> skin.</summary>
public record SkiffDyeSlot
{
    /// <summary>The default dye configuration for this slot; see <see cref="SkiffDyeSlotDefault"/>.</summary>
    [JsonPropertyName("default")]
    public SkiffDyeSlotDefault? Default { get; init; } = null;
}

/// <summary>Represents the default dye configuration within a <see cref="SkiffDyeSlot"/>.</summary>
public record SkiffDyeSlotDefault
{
    /// <summary>Default color ID applied to this slot; resolvable to a <see cref="Dye"/>.</summary>
    [JsonPropertyName("color_id")]
    public required int ColorId { get; init; }

    /// <summary>Material type of this slot, which affects how the dye renders (e.g., "Leather", "Metal", "Cloth").</summary>
    [JsonPropertyName("material")]
    public required string Material { get; init; }
}
