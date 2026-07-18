using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsuraGate.Spec.Models.V2;

/// <summary>Represents a cosmetic skin that can be applied to equipment through the wardrobe system.</summary>
public record Skin
{
    /// <summary>Unique skin ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the skin.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Skin category: "Armor", "Weapon", "Back", or "Gathering".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>List of behavior flags (e.g., "ShowInWardrobe", "NoCost", "HideIfLocked").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>List of race or profession restrictions on this skin; empty if unrestricted.</summary>
    [JsonPropertyName("restrictions")]
    public string[] Restrictions { get; init; } = [];

    /// <summary>URL to the skin's icon image; null for some skins.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Rarity tier of the skin (e.g., "Exotic", "Legendary").</summary>
    [JsonPropertyName("rarity")]
    public required string Rarity { get; init; }

    /// <summary>Flavor text or lore description associated with this skin; null if not provided.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Type-specific skin details; null if no details are present; see <see cref="SkinDetails"/>.</summary>
    [JsonPropertyName("details")]
    public JsonElement? Details { get; init; }
    
    public SkinDetails? GetDetails() => Details?.Deserialize<SkinDetails>();

    private static SkinDetails? DeserializeSkinDetails(JsonElement element)
    {
        if (!element.TryGetProperty("type", out var typeProp))
        {
            return element.Deserialize<SkinDetails>();
        }

        return typeProp.GetString() switch
        {
            "Armor" => element.Deserialize<SkinArmorDetails>(),
            "Weapon" => element.Deserialize<SkinWeaponDetails>(),
            "Back" => element.Deserialize<SkinBackDetails>(),
            "Gathering" => element.Deserialize<SkinGatheringDetails>(),
            _ => element.Deserialize<SkinDetails>()
        };
    }
}

/// <summary>
/// Polymorphic container for type-specific skin details within a <see cref="Skin"/>.
/// Possible subtypes: <see cref="SkinArmorDetails"/>, <see cref="SkinWeaponDetails"/>,
/// <see cref="SkinBackDetails"/>, <see cref="SkinGatheringDetails"/>.
/// </summary>
public abstract record SkinDetails;

/// <summary>Skin details for an armor piece within <see cref="SkinDetails"/>.</summary>
public record SkinArmorDetails : SkinDetails
{
    /// <summary>Armor slot type (e.g., "Helm", "Shoulders", "Coat", "Gloves", "Leggings", "Boots").</summary>
    [JsonPropertyName("type")]
    public string Type { get; init; }

    /// <summary>Armor weight class: "Light", "Medium", or "Heavy".</summary>
    [JsonPropertyName("weight_class")]
    public required string WeightClass { get; init; }

    /// <summary>Dye slot configuration for this armor skin; null if not present; see <see cref="SkinDyeSlot"/>.</summary>
    [JsonPropertyName("dye_slots")]
    public SkinDyeSlot? DyeSlots { get; init; }
}

/// <summary>Dye slot configuration for a <see cref="SkinArmorDetails"/> skin.</summary>
public record SkinDyeSlot
{
    /// <summary>Default dye configuration applied to each dye channel; see <see cref="SkinDefaultSlot"/>.</summary>
    [JsonPropertyName("default")]
    public SkinDefaultSlot[] Default { get; init; } = [];
}

/// <summary>Default dye slot data for a single dye channel within a <see cref="SkinDyeSlot"/>.</summary>
public record SkinDefaultSlot
{
    /// <summary>Default dye color applied in this channel; resolvable to a <see cref="Dye"/>.</summary>
    [JsonPropertyName("color_id")]
    public required int ColorId { get; init; }

    /// <summary>Material type determining how the dye renders (e.g., "cloth", "leather", "metal").</summary>
    [JsonPropertyName("material")]
    public required string Material { get; init; }
}

/// <summary>Skin details for a weapon within <see cref="SkinDetails"/>.</summary>
public record SkinWeaponDetails : SkinDetails
{
    /// <summary>Weapon type (e.g., "Sword", "Greatsword", "Staff", "Longbow").</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    /// <summary>Damage type of the weapon skin (e.g., "Physical", "Fire", "Ice").</summary>
    [JsonPropertyName("damage_type")]
    public required string DamageType { get; init; }
}

/// <summary>Skin details for a back item within <see cref="SkinDetails"/>; contains no additional fields.</summary>
public record SkinBackDetails : SkinDetails;

/// <summary>Skin details for a gathering tool within <see cref="SkinDetails"/>.</summary>
public record SkinGatheringDetails : SkinDetails
{
    /// <summary>Gathering tool type: "Foraging", "Logging", or "Mining".</summary>
    [JsonPropertyName("type")]
    public required string Type { get; init; }
}
