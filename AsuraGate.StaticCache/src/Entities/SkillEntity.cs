using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skill"/>.
/// </summary>
[Table("skills")]
public class SkillEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Column("chat_link")]
    public string? ChatLink { get; set; }

    [Indexed, Column("type")]
    public string? Type { get; set; }

    [Indexed, Column("weapon_type")]
    public string? WeaponType { get; set; }

    [Indexed, Column("slot")]
    public string? Slot { get; set; }

    [Indexed, Column("attunement")]
    public string? Attunement { get; set; }

    [Column("cost")]
    public int? Cost { get; set; }

    [Column("dual_wield")]
    public string? DualWield { get; set; }

    [Indexed, Column("flip_skill")]
    public int? FlipSkill { get; set; } // FK to SkillEntity

    [Column("initiative")]
    public int? Initiative { get; set; }

    [Indexed, Column("next_chain")]
    public int? NextChain { get; set; } // FK to SkillEntity

    [Indexed, Column("previous_chain")]
    public int? PreviousChain { get; set; } // FK to SkillEntity

    [Indexed, Column("specialization")]
    public int? Specialization { get; set; } // FK to SpecializationEntity
}

/// <summary>Professions with access to a <see cref="SkillEntity"/>.</summary>
[Table("skill_professions")]
public class SkillProfessionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("profession")]
    public string Profession { get; set; } = string.Empty;
}

/// <summary>Category tags on a <see cref="SkillEntity"/> (e.g. "Signet", "Well").</summary>
[Table("skill_categories")]
public class SkillCategoryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("category")]
    public string Category { get; set; } = string.Empty;
}

/// <summary>Behavior flags on a <see cref="SkillEntity"/> (e.g. "GroundTargeted").</summary>
[Table("skill_flags")]
public class SkillFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Skills available while a <see cref="SkillEntity"/>'s transformation, bundle, or toolbelt is active.</summary>
[Table("skill_related_skills")]
public class SkillRelatedSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("relation")]
    public string Relation { get; set; } = string.Empty; // "Transform", "Bundle", or "Toolbelt"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("related_skill_id")]
    public int RelatedSkillId { get; set; } // FK to SkillEntity
}

/// <summary>
/// A single tooltip fact (from either <c>Facts</c> or <c>TraitedFacts</c>) belonging to a <see cref="SkillEntity"/>.
/// One table covers every <c>SkillFact</c> subtype; only the columns relevant to <see cref="FactType"/> are populated.
/// </summary>
[Table("skill_facts")]
public class SkillFactEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("kind")]
    public string Kind { get; set; } = string.Empty; // "Base" (Facts) or "Traited" (TraitedFacts)

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("text")]
    public string? Text { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Indexed, Column("fact_type")]
    public string? FactType { get; set; } // discriminator, e.g. "Damage", "Buff", "Number"...

    // AttributeAdjust.Value / Number.Value / Range.Value / Recharge.Value
    [Column("value")]
    public int? Value { get; set; }

    // AttributeAdjust.Target
    [Column("target")]
    public string? Target { get; set; }

    // Buff.Status / PrefixedBuff.Status
    [Column("status")]
    public string? Status { get; set; }

    // Buff.Description / PrefixedBuff.Description
    [Column("fact_description")]
    public string? FactDescription { get; set; }

    // Buff.ApplyCount / PrefixedBuff.ApplyCount
    [Column("apply_count")]
    public int? ApplyCount { get; set; }

    // Buff.Duration / Duration.Duration / PrefixedBuff.Duration / Time.Duration
    [Column("duration")]
    public int? Duration { get; set; }

    // ComboField.FieldType
    [Column("field_type")]
    public string? FieldType { get; set; }

    // ComboFinisher.FinisherType
    [Column("finisher_type")]
    public string? FinisherType { get; set; }

    // ComboFinisher.Percent / Percent.Percent
    [Column("percent")]
    public int? Percent { get; set; }

    // Damage.HitCount / Heal.HitCount / HealingAdjust.HitCount
    [Column("hit_count")]
    public int? HitCount { get; set; }

    // Damage.DamageMultiplier
    [Column("dmg_multiplier")]
    public double? DamageMultiplier { get; set; }

    // Distance.Distance / Radius.Distance
    [Column("distance")]
    public int? Distance { get; set; }

    // StunBreak.Value / Unblockable.Value
    [Column("bool_value")]
    public bool? BoolValue { get; set; }

    // PrefixedBuff.Prefix.*
    [Column("prefix_text")] public string? PrefixText { get; set; }
    [Column("prefix_icon")] public string? PrefixIcon { get; set; }
    [Column("prefix_status")] public string? PrefixStatus { get; set; }
    [Column("prefix_description")] public string? PrefixDescription { get; set; }
}
