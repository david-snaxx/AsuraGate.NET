using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skill"/>.
/// </summary>
[Table("skills")]
public class SkillEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Column("chat_link")]
    public string? ChatLink { get; set; }

    [Indexed]
    [Column("type")]
    public string? Type { get; set; }

    [Column("weapon_type")]
    public string? WeaponType { get; set; }

    [Column("slot")]
    public string? Slot { get; set; }

    [Column("attunement")]
    public string? Attunement { get; set; }

    [Column("cost")]
    public int? Cost { get; set; }

    [Column("dual_wield")]
    public string? DualWield { get; set; }

    [Column("flip_skill")]
    public int? FlipSkill { get; set; }

    [Column("initiative")]
    public int? Initiative { get; set; }

    [Column("next_chain")]
    public int? NextChain { get; set; }

    [Column("previous_chain")]
    public int? PreviousChain { get; set; }

    [Indexed]
    [Column("specialization")]
    public int? Specialization { get; set; }
}

/// <summary>Profession with access to a <see cref="SkillEntity"/>.</summary>
[Table("skill_professions")]
public class SkillProfessionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;
}

/// <summary>Category tag on a <see cref="SkillEntity"/>.</summary>
[Table("skill_categories")]
public class SkillCategoryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("category")]
    public string Category { get; set; } = string.Empty;
}

/// <summary>Behavior flag on a <see cref="SkillEntity"/>.</summary>
[Table("skill_flags")]
public class SkillFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Skill ID related to a <see cref="SkillEntity"/> via a transform/bundle/toolbelt/kit relationship.</summary>
[Table("skill_related_skills")]
public class SkillRelatedSkillEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Indexed]
    [Column("relation")]
    public string Relation { get; set; } = string.Empty; // "Transform", "Bundle", "Toolbelt"

    [NotNull]
    [Column("related_skill_id")]
    public int RelatedSkillId { get; set; }
}

/// <summary>
/// A tooltip fact entry (base or traited) for a <see cref="SkillEntity"/> - a union of every
/// <c>SkillFact</c> subtype's fields, the same discriminator-table idea as Achievement's rewards.
/// <see cref="IsTraited"/> distinguishes the base <c>facts</c> list from <c>traited_facts</c>.
/// </summary>
[Table("skill_facts")]
public class SkillFactEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("is_traited")]
    public bool IsTraited { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("text")]
    public string? Text { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [NotNull]
    [Indexed]
    [Column("fact_type")]
    public string FactType { get; set; } = string.Empty;

    [Column("value_int")]
    public int? ValueInt { get; set; } // AttributeAdjust/Number/Range/Recharge value

    [Column("target")]
    public string? Target { get; set; } // AttributeAdjust

    [Column("status")]
    public string? Status { get; set; } // Buff/PrefixedBuff

    [Column("buff_description")]
    public string? BuffDescription { get; set; } // Buff/PrefixedBuff

    [Column("apply_count")]
    public int? ApplyCount { get; set; } // Buff/PrefixedBuff

    [Column("duration")]
    public int? Duration { get; set; } // Buff/ComboFinisher(percent uses separate col)/Duration/PrefixedBuff/Time

    [Column("field_type")]
    public string? FieldType { get; set; } // ComboField

    [Column("finisher_type")]
    public string? FinisherType { get; set; } // ComboFinisher

    [Column("percent")]
    public int? Percent { get; set; } // ComboFinisher/Percent

    [Column("hit_count")]
    public int? HitCount { get; set; } // Damage/Heal/HealingAdjust

    [Column("damage_multiplier")]
    public float? DamageMultiplier { get; set; } // Damage

    [Column("distance")]
    public int? Distance { get; set; } // Distance/Radius

    [Column("bool_value")]
    public bool? BoolValue { get; set; } // StunBreak/Unblockable

    [Column("prefix_text")]
    public string? PrefixText { get; set; } // PrefixedBuff.Prefix

    [Column("prefix_icon")]
    public string? PrefixIcon { get; set; }

    [Column("prefix_status")]
    public string? PrefixStatus { get; set; }

    [Column("prefix_description")]
    public string? PrefixDescription { get; set; }
}
