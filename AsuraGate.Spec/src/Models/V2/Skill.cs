using System.Text.Json;
using System.Text.Json.Serialization;

namespace AsuraGate.Fetch.Model;

/// <summary>Represents a playable skill available to a profession, weapon, or bundle.</summary>
public record Skill
{
    /// <summary>Unique skill ID.</summary>
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

    /// <summary>In-game chat link for sharing this skill in chat; null for some skills.</summary>
    [JsonPropertyName("chat_link")]
    public string? ChatLink { get; init; }

    /// <summary>Skill category (e.g., "Weapon", "Heal", "Utility", "Elite", "Profession", "Monster"); null for some skills.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    /// <summary>Weapon type this skill is tied to (e.g., "Sword", "Staff"); null for non-weapon skills.</summary>
    [JsonPropertyName("weapon_type")]
    public string? WeaponType { get; init; }

    /// <summary>List of profession names that have access to this skill (e.g., "Guardian", "Mesmer").</summary>
    [JsonPropertyName("professions")]
    public string[] Professions { get; init; } = [];

    /// <summary>Skill bar slot (e.g., "Weapon_1" through "Weapon_5", "Heal", "Utility", "Elite", "Downed_1" through "Downed_4"); null for some skills.</summary>
    [JsonPropertyName("slot")]
    public string? Slot { get; init; }

    /// <summary>List of base tooltip fact entries describing the skill's effects; see <see cref="SkillFact"/>.</summary>
    [JsonPropertyName("facts")]
    public JsonElement[] Facts { get; init; } = [];

    /// <summary>List of tooltip facts that replace or supplement base facts when specific traits are equipped; see <see cref="SkillFact"/>.</summary>
    [JsonPropertyName("traited_facts")]
    public JsonElement[] TraitedFacts { get; init; } = [];
    
    public SkillFact?[] GetFacts() => Facts.Select(DeserializeSkillFact).ToArray();
    public SkillFact?[] GetTraitedFacts() => TraitedFacts.Select(DeserializeSkillFact).ToArray();

    private static SkillFact? DeserializeSkillFact(JsonElement element)
    {
        if (!element.TryGetProperty("type", out var typeProp)) 
            return element.Deserialize<SkillFact>();
    
        return typeProp.GetString() switch
        {
            "AttributeAdjust" => element.Deserialize<SkillFactAttributeAdjust>(),
            "Buff" => element.Deserialize<SkillFactBuff>(),
            "ComboField" => element.Deserialize<SkillFactComboField>(),
            "ComboFinisher" => element.Deserialize<SkillFactComboFinisher>(),
            "Damage" => element.Deserialize<SkillFactDamage>(),
            "Distance" => element.Deserialize<SkillFactDistance>(),
            "Duration" => element.Deserialize<SkillFactDuration>(),
            "Heal" => element.Deserialize<SkillFactHeal>(),
            "HealingAdjust" => element.Deserialize<SkillFactHealingAdjust>(),
            "NoData" => element.Deserialize<SkillFactNoData>(),
            "Number" => element.Deserialize<SkillFactNumber>(),
            "Percent" => element.Deserialize<SkillFactPercent>(),
            "PrefixedBuff" => element.Deserialize<SkillFactPrefixedBuff>(),
            "Radius" => element.Deserialize<SkillFactRadius>(),
            "Range" => element.Deserialize<SkillFactRange>(),
            "Recharge" => element.Deserialize<SkillFactRecharge>(),
            "StunBreak" => element.Deserialize<SkillFactStunBreak>(),
            "Time" => element.Deserialize<SkillFactTime>(),
            "Unblockable" => element.Deserialize<SkillFactUnblockable>(),
            _ => element.Deserialize<SkillFact>()
        };
    }

    /// <summary>List of skill category tags (e.g., "Signet", "Well", "Ward", "Shout").</summary>
    [JsonPropertyName("categories")]
    public string[] Categories { get; init; } = [];

    /// <summary>Elementalist attunement required for this skill (e.g., "Fire", "Water", "Air", "Earth"); null for non-elementalist skills.</summary>
    [JsonPropertyName("attunement")]
    public string? Attunement { get; init; }

    /// <summary>Resource cost to activate — initiative for thieves, energy for revenants; null if no cost.</summary>
    [JsonPropertyName("cost")]
    public int? Cost { get; init; }

    /// <summary>Off-hand weapon type required for this dual-wield skill (e.g., "Pistol", "Dagger"); null if not a dual-wield skill.</summary>
    [JsonPropertyName("dual_wield")]
    public string? DualWield { get; init; }

    /// <summary>ID of the skill this becomes after activation (e.g., a toggle-off state); resolvable to a <see cref="Skill"/>; null if not applicable.</summary>
    [JsonPropertyName("flip_skill")]
    public int? FlipSkill { get; init; }

    /// <summary>Initiative cost for thief skills specifically; null for other professions.</summary>
    [JsonPropertyName("initiative")]
    public int? Initiative { get; init; }

    /// <summary>ID of the next skill in a chain sequence; resolvable to a <see cref="Skill"/>; null if this is the last in the chain.</summary>
    [JsonPropertyName("next_chain")]
    public int? NextChain { get; init; }

    /// <summary>ID of the previous skill in a chain sequence; resolvable to a <see cref="Skill"/>; null if this is the first in the chain.</summary>
    [JsonPropertyName("prev_chain")]
    public int? PreviousChain { get; init; }

    /// <summary>List of skill IDs available while this skill's transformation is active; each resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("transform_skills")]
    public int[] TransformSkills { get; init; } = [];

    /// <summary>List of skill IDs available while the bundle associated with this skill is wielded; each resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("bundle_skills")]
    public int[] BundleSkills { get; init; } = [];

    /// <summary>List of skill IDs placed in the engineer's toolbelt slot when this kit is equipped; each resolvable to a <see cref="Skill"/>.</summary>
    [JsonPropertyName("toolbelt_skills")]
    public int[] ToolbeltSkills { get; init; } = [];

    /// <summary>List of behavior flags (e.g., "GroundTargeted", "NoUnderwater", "NotSelectable").</summary>
    [JsonPropertyName("flags")]
    public string[] Flags { get; init; } = [];

    /// <summary>ID of the specialization required to use this skill; resolvable to a <see cref="Specialization"/>; null if not specialization-gated.</summary>
    [JsonPropertyName("specialization")]
    public int? Specialization { get; init; }
}

/// <summary>
/// Polymorphic tooltip fact entry describing an aspect of a <see cref="Skill"/>'s effect.
/// Possible subtypes determined by the "type" field include:
/// <see cref="SkillFactAttributeAdjust"/>, <see cref="SkillFactBuff"/>, <see cref="SkillFactComboField"/>,
/// <see cref="SkillFactComboFinisher"/>, <see cref="SkillFactDamage"/>, <see cref="SkillFactDistance"/>,
/// <see cref="SkillFactDuration"/>, <see cref="SkillFactHeal"/>, <see cref="SkillFactHealingAdjust"/>,
/// <see cref="SkillFactNoData"/>, <see cref="SkillFactNumber"/>, <see cref="SkillFactPercent"/>,
/// <see cref="SkillFactPrefixedBuff"/>, <see cref="SkillFactRadius"/>, <see cref="SkillFactRange"/>,
/// <see cref="SkillFactRecharge"/>, <see cref="SkillFactStunBreak"/>, <see cref="SkillFactTime"/>,
/// <see cref="SkillFactUnblockable"/>.
/// </summary>
public record SkillFact
{
    /// <summary>Display label shown in the tooltip for this fact.</summary>
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    /// <summary>URL to the icon associated with this fact entry.</summary>
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }

    /// <summary>Discriminator string identifying the fact subtype.</summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; } = null;
}

/// <summary>A <see cref="SkillFact"/> describing a numeric adjustment to a character attribute.</summary>
public record SkillFactAttributeAdjust : SkillFact
{
    /// <summary>Numeric amount by which the target attribute is adjusted.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }

    /// <summary>Attribute affected by this adjustment (e.g., "Power", "Precision", "Ferocity", "Healing"); null if not specified.</summary>
    [JsonPropertyName("target")]
    public string? Target { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a boon or condition applied by the skill.</summary>
public record SkillFactBuff : SkillFact
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

/// <summary>A <see cref="SkillFact"/> describing a combo field element created by the skill.</summary>
public record SkillFactComboField : SkillFact
{
    /// <summary>Element type of the combo field (e.g., "Fire", "Water", "Lightning", "Dark", "Poison").</summary>
    [JsonPropertyName("field_type")]
    public required string FieldType { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a combo finisher effect triggered by the skill.</summary>
public record SkillFactComboFinisher : SkillFact
{
    /// <summary>Type of combo finisher (e.g., "Blast", "Projectile", "Leap", "Whirl").</summary>
    [JsonPropertyName("finisher_type")]
    public required string FinisherType { get; init; }

    /// <summary>Chance (0–100) that this skill triggers as a combo finisher.</summary>
    [JsonPropertyName("percent")]
    public required int Percent { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing damage dealt by the skill.</summary>
public record SkillFactDamage : SkillFact
{
    /// <summary>Number of times this attack hits per activation.</summary>
    [JsonPropertyName("hit_count")]
    public required int HitCount { get; init; }

    /// <summary>Damage coefficient multiplied against weapon strength and power to compute final damage.</summary>
    [JsonPropertyName("dmg_multiplier")]
    public required float DamageMultiplier { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a distance value associated with the skill.</summary>
public record SkillFactDistance : SkillFact
{
    /// <summary>Distance value in game units.</summary>
    [JsonPropertyName("distance")]
    public required int Distance { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a time duration associated with the skill.</summary>
public record SkillFactDuration : SkillFact
{
    /// <summary>Duration in seconds.</summary>
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing healing applied by the skill.</summary>
public record SkillFactHeal : SkillFact
{
    /// <summary>Number of times this skill applies healing per activation.</summary>
    [JsonPropertyName("hit_count")]
    public required int HitCount { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a healing amount that scales with healing power.</summary>
public record SkillFactHealingAdjust : SkillFact
{
    /// <summary>Number of healing applications per activation.</summary>
    [JsonPropertyName("hit_count")]
    public required int HitCount { get; init; }
}

/// <summary>A <see cref="SkillFact"/> placeholder used when no structured data is available for display.</summary>
public record SkillFactNoData : SkillFact;

/// <summary>A <see cref="SkillFact"/> displaying a generic numeric value.</summary>
public record SkillFactNumber : SkillFact
{
    /// <summary>Numeric value displayed in the tooltip.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="SkillFact"/> displaying a percentage value.</summary>
public record SkillFactPercent : SkillFact
{
    /// <summary>Percentage value displayed in the tooltip.</summary>
    [JsonPropertyName("percent")]
    public required int Percent { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a boon or condition that is prefixed with an additional boon grant.</summary>
public record SkillFactPrefixedBuff : SkillFact
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

    /// <summary>Boon prepended to this fact in the tooltip; see <see cref="SkillFactPrefix"/>; null if not specified.</summary>
    [JsonPropertyName("prefix")]
    public SkillFactPrefix? Prefix { get; init; }
}

/// <summary>Represents the boon prefix entry within a <see cref="SkillFactPrefixedBuff"/> fact.</summary>
public record SkillFactPrefix
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

/// <summary>A <see cref="SkillFact"/> describing the area-of-effect radius of the skill.</summary>
public record SkillFactRadius : SkillFact
{
    /// <summary>Radius size in game units.</summary>
    [JsonPropertyName("distance")]
    public required int Distance { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing the maximum range of the skill.</summary>
public record SkillFactRange : SkillFact
{
    /// <summary>Maximum range in game units.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing the cooldown or recharge time of the skill.</summary>
public record SkillFactRecharge : SkillFact
{
    /// <summary>Cooldown duration in seconds.</summary>
    [JsonPropertyName("value")]
    public required int Value { get; init; }
}

/// <summary>A <see cref="SkillFact"/> indicating that this skill breaks stun and other control effects.</summary>
public record SkillFactStunBreak : SkillFact
{
    /// <summary>Always true; confirms this skill can break stun effects.</summary>
    [JsonPropertyName("value")]
    public required bool Value { get; init; }
}

/// <summary>A <see cref="SkillFact"/> describing a duration value in seconds.</summary>
public record SkillFactTime : SkillFact
{
    /// <summary>Duration in seconds.</summary>
    [JsonPropertyName("duration")]
    public required int Duration { get; init; }
}

/// <summary>A <see cref="SkillFact"/> indicating that the skill's effect cannot be blocked or evaded.</summary>
public record SkillFactUnblockable : SkillFact
{
    /// <summary>Always true; confirms this skill's effect is unblockable.</summary>
    [JsonPropertyName("value")]
    public required bool Value { get; init; }
}
