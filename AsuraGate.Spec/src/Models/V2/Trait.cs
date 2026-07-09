using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a trait that can be slotted into a <see cref="Specialization"/> to modify profession abilities.</summary>
public record Trait
{
    /// <summary>Unique trait ID.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the trait.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>URL to the trait's icon image.</summary>
    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    /// <summary>Description of the trait's passive or active effect; null for some traits.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>ID of the specialization this trait belongs to; resolvable to a <see cref="Specialization"/>.</summary>
    [JsonPropertyName("specialization")]
    public required int Specialization { get; init; }

    /// <summary>Tier of the trait within its specialization (1, 2, or 3).</summary>
    [JsonPropertyName("tier")]
    public required int Tier { get; init; }

    /// <summary>Display order index of the trait within its tier column.</summary>
    [JsonPropertyName("order")]
    public required int Order { get; init; }

    /// <summary>Trait slot type: "Minor" (always active) or "Major" (player-selectable).</summary>
    [JsonPropertyName("slot")]
    public required string Slot { get; init; }

    /// <summary>List of tooltip fact entries describing the trait's effects; see <see cref="TraitFact"/>.</summary>
    [JsonPropertyName("facts")]
    public JsonElement[] Facts { get; init; } = [];

    public TraitFact?[] GetFacts(string type) => Facts.Select(DeserializeTraitFact).ToArray();

    private static TraitFact? DeserializeTraitFact(JsonElement element)
    {
        if (!element.TryGetProperty("type", out var typeProp))
        {
            return element.Deserialize<TraitFact>();
        }

        return typeProp.GetString() switch
        {
            "AttributeAdjust" => element.Deserialize<TraitFactAttributeAdjust>(),
            "Buff" => element.Deserialize<TraitFactBuff>(),
            "BuffConversion" => element.Deserialize<TraitFactBuffConversion>(),
            "ComboField" => element.Deserialize<TraitFactComboField>(),
            "ComboFinisher" => element.Deserialize<TraitFactComboFinisher>(),
            "Damage" => element.Deserialize<TraitFactDamage>(),
            "Distance" => element.Deserialize<TraitFactDistance>(),
            "NoData" => element.Deserialize<TraitFactNoData>(),
            "Number" => element.Deserialize<TraitFactNoData>(),
            "Percent" => element.Deserialize<TraitFactPercent>(),
            "PrefixedBuff" => element.Deserialize<TraitFactPrefixedBuff>(),
            "Radius" => element.Deserialize<TraitFactRadius>(),
            "Range" => element.Deserialize<TraitFactRange>(),
            "Recharge" => element.Deserialize<TraitFactRecharge>(),
            "Time" => element.Deserialize<TraitFactTime>(),
            "Unblockable" => element.Deserialize<TraitFactUnblockable>(),
            _ => element.Deserialize<TraitFact>()
        };
    }

    /// <summary>List of skills that this trait modifies or enables; see <see cref="TraitSkill"/>.</summary>
    [JsonPropertyName("skills")]
    public TraitSkill[] Skills { get; init; } = [];
}

/// <summary>
/// Polymorphic tooltip fact entry describing an aspect of a <see cref="Trait"/>'s effect.
/// Possible subtypes determined by the "type" field include:
/// <see cref="TraitFactAttributeAdjust"/>, <see cref="TraitFactBuff"/>, <see cref="TraitFactBuffConversion"/>,
/// <see cref="TraitFactComboField"/>, <see cref="TraitFactComboFinisher"/>, <see cref="TraitFactDamage"/>,
/// <see cref="TraitFactDistance"/>, <see cref="TraitFactNoData"/>, <see cref="TraitFactNumber"/>,
/// <see cref="TraitFactPercent"/>, <see cref="TraitFactPrefixedBuff"/>, <see cref="TraitFactRadius"/>,
/// <see cref="TraitFactRange"/>, <see cref="TraitFactRecharge"/>, <see cref="TraitFactTime"/>,
/// <see cref="TraitFactUnblockable"/>.
/// </summary>
public record TraitFact
{
    /// <summary>Display label shown in the tooltip for this fact.</summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>URL to the icon associated with this fact entry.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Discriminator string identifying the fact subtype.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a numeric adjustment to a character attribute.</summary>
public record TraitFactAttributeAdjust : TraitFact
{
    /// <summary>Numeric amount by which the target attribute is adjusted.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }

    /// <summary>Attribute affected (e.g., "Power", "Precision", "Ferocity", "Vitality"); null if not specified.</summary>
    [JsonPropertyName("target")]
    public string? Target { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a boon or condition applied by the trait.</summary>
public record TraitFactBuff : TraitFact
{
    /// <summary>Name of the boon or condition applied (e.g., "Might", "Fury", "Burning", "Bleeding"); null if not specified.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>Description of the boon or condition's effect; null if not specified.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Number of stacks applied; null if not applicable.</summary>
    [JsonPropertyName("apply_count")]
    public int? ApplyCount { get; init; }

    /// <summary>Duration in seconds the buff is applied; null if not applicable.</summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a conversion from one attribute into another.</summary>
public record TraitFactBuffConversion : TraitFact
{
    /// <summary>Attribute whose value drives the conversion (e.g., "Power", "Toughness").</summary>
    [JsonPropertyName("source")]
    public required string Source { get; init; }

    /// <summary>Percentage of the source attribute value added to the target attribute.</summary>
    [JsonPropertyName("percent")]
    public required string Percent { get; init; }

    /// <summary>Attribute that receives the converted bonus (e.g., "ConditionDamage", "Healing").</summary>
    [JsonPropertyName("target")]
    public required string Target { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a combo field element created by the trait.</summary>
public record TraitFactComboField : TraitFact
{
    /// <summary>Element type of the combo field (e.g., "Fire", "Water", "Lightning", "Dark", "Poison").</summary>
    [JsonPropertyName("field_type")]
    public required string FieldType { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a combo finisher effect triggered by the trait.</summary>
public record TraitFactComboFinisher : TraitFact
{
    /// <summary>Type of combo finisher (e.g., "Blast", "Projectile", "Leap", "Whirl").</summary>
    [JsonPropertyName("finisher_type")]
    public required string FinisherType { get; init; }

    /// <summary>Chance (0–100) that this trait triggers as a combo finisher.</summary>
    [JsonPropertyName("percent")]
    public required int Percent { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing damage dealt by the trait.</summary>
public record TraitFactDamage : TraitFact
{
    /// <summary>Number of times the damage is applied per activation.</summary>
    [JsonPropertyName("hit_count")]
    public required int HitCount { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a distance value associated with the trait.</summary>
public record TraitFactDistance : TraitFact
{
    /// <summary>Distance value in game units.</summary>
    [JsonPropertyName("distance")]
    public required int Distance { get; init; }
}

/// <summary>A <see cref="TraitFact"/> placeholder used when no structured data is available for display.</summary>
public record TraitFactNoData : TraitFact;

/// <summary>A <see cref="TraitFact"/> displaying a generic numeric value.</summary>
public record TraitFactNumber : TraitFact
{
    /// <summary>Numeric value displayed in the tooltip.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="TraitFact"/> displaying a percentage value.</summary>
public record TraitFactPercent : TraitFact
{
    /// <summary>Percentage value displayed in the tooltip.</summary>
    [JsonPropertyName("percent")]
    public required int Percent { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a boon or condition that is prefixed with an additional boon grant.</summary>
public record TraitFactPrefixedBuff : TraitFact
{
    /// <summary>Duration in seconds the main buff is applied.</summary>
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }

    /// <summary>Name of the boon or condition applied (e.g., "Might", "Fury"); null if not specified.</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>Description of the main buff or condition's effect; null if not specified.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>Number of stacks of the main buff applied.</summary>
    [JsonPropertyName("apply_count")]
    public required int ApplyCount { get; init; }

    /// <summary>Boon prepended to this fact in the tooltip; null if not specified; see <see cref="TraitFactPrefix"/>.</summary>
    [JsonPropertyName("prefix")]
    public TraitFactPrefix? Prefix { get; init; }
}

/// <summary>Represents the boon prefix entry within a <see cref="TraitFactPrefixedBuff"/> fact.</summary>
public record TraitFactPrefix
{
    /// <summary>Display label for this prefix entry.</summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>URL to the prefix boon's icon.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Name of the boon granted as the prefix (e.g., "Might", "Fury").</summary>
    [JsonPropertyName("status")]
    public string? Status { get; init; }

    /// <summary>Description of the prefix boon's effect.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing the area-of-effect radius of the trait.</summary>
public record TraitFactRadius : TraitFact
{
    /// <summary>Radius size in game units.</summary>
    [JsonPropertyName("distance")]
    public required int Distance { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing the maximum range of the trait.</summary>
public record TraitFactRange : TraitFact
{
    /// <summary>Maximum range in game units.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing the cooldown or recharge time of the trait.</summary>
public record TraitFactRecharge : TraitFact
{
    /// <summary>Cooldown duration in seconds.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="TraitFact"/> describing a duration value in seconds.</summary>
public record TraitFactTime : TraitFact
{
    /// <summary>Duration in seconds.</summary>
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }
}

/// <summary>A <see cref="TraitFact"/> indicating that the trait's effect cannot be blocked or evaded.</summary>
public record TraitFactUnblockable : TraitFact
{
    /// <summary>Always true; confirms this trait's effect is unblockable.</summary>
    [JsonPropertyName("value")]
    public required bool Value { get; init; }
}

/// <summary>Represents a skill that is modified or enabled by a <see cref="Trait"/>.</summary>
public record TraitSkill
{
    /// <summary>Unique skill ID; resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    /// <summary>Display name of the skill.</summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>Description of the skill's effect; null for some skills.</summary>
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    /// <summary>URL to the skill's icon image; null for some skills.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>List of base tooltip facts for this skill; see <see cref="TraitFact"/>.</summary>
    [JsonPropertyName("facts")]
    public TraitFact[] Facts { get; init; } = [];

    /// <summary>List of tooltip facts that replace or supplement base facts when specific traits are equipped; see <see cref="TraitFact"/>.</summary>
    [JsonPropertyName("traited_facts")]
    public TraitFact[] TraitedFacts { get; init; } = [];
}
