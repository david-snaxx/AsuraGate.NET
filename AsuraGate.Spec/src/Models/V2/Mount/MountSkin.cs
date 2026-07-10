using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2.Mount;

/// <summary>Represents a mount skin cosmetic that overrides a mount's default appearance.</summary>
public record MountSkin
{
    /// <summary>Unique mount skin ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the skin.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the skin preview icon.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>List of dye slot definitions for this skin; see <see cref="MountDyeSlot"/>.</summary>
    [JsonPropertyName("dye_slots")]
    public MountDyeSlot[] DyeSlots { get; init; } = [];

    /// <summary>String identifier of the mount type this skin applies to (e.g., "raptor", "springer").</summary>
    [JsonPropertyName("mount")]
    public required string Mount { get; init; }

    /// <summary>Internal GUID for the mount skin.</summary>
    [JsonPropertyName("mount_guid")]
    public string? MountGuid { get; init; } = null;
}

/// <summary>Represents a single dye slot on a <see cref="MountSkin"/>.</summary>
public record MountDyeSlot
{
    /// <summary>Default color ID applied to this slot; resolvable to a <see cref="Dye"/>.</summary>
    [JsonPropertyName("color_id")]
    public required int ColorId { get; init; }

    /// <summary>Material type of this slot, which affects how the dye renders (e.g., "cloth", "leather", "metal").</summary>
    [JsonPropertyName("material")]
    public required string Material { get; init; }
}
