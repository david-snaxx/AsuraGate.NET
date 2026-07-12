using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Trait"/>.
/// </summary>
[Table("traits")]
public class TraitEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [NotNull]
    [Indexed]
    [Column("specialization")]
    public int Specialization { get; set; }

    [NotNull]
    [Column("tier")]
    public int Tier { get; set; }

    [NotNull]
    [Column("order")]
    public int Order { get; set; }

    [NotNull]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;
}

/// <summary>
/// A tooltip fact entry for a <see cref="TraitEntity"/> - a union of every <c>TraitFact</c> subtype's
/// fields, the same idea as <c>SkillFactEntity</c>.
/// </summary>
[Table("trait_facts")]
public class TraitFactEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("trait_id")]
    public int TraitId { get; set; }

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
    public int? ValueInt { get; set; } // AttributeAdjust/Number/Range/Recharge

    [Column("target")]
    public string? Target { get; set; } // AttributeAdjust/BuffConversion

    [Column("status")]
    public string? Status { get; set; } // Buff/PrefixedBuff

    [Column("buff_description")]
    public string? BuffDescription { get; set; } // Buff/PrefixedBuff

    [Column("apply_count")]
    public int? ApplyCount { get; set; } // Buff/PrefixedBuff

    [Column("duration")]
    public int? Duration { get; set; } // Buff/PrefixedBuff/Time

    [Column("source")]
    public string? Source { get; set; } // BuffConversion

    [Column("buff_conversion_percent")]
    public string? BuffConversionPercent { get; set; } // BuffConversion (modelled as string on the source model)

    [Column("field_type")]
    public string? FieldType { get; set; } // ComboField

    [Column("finisher_type")]
    public string? FinisherType { get; set; } // ComboFinisher

    [Column("percent")]
    public int? Percent { get; set; } // ComboFinisher/Percent

    [Column("hit_count")]
    public int? HitCount { get; set; } // Damage

    [Column("distance")]
    public int? Distance { get; set; } // Distance/Radius

    [Column("bool_value")]
    public bool? BoolValue { get; set; } // Unblockable

    [Column("prefix_text")]
    public string? PrefixText { get; set; } // PrefixedBuff.Prefix

    [Column("prefix_icon")]
    public string? PrefixIcon { get; set; }

    [Column("prefix_status")]
    public string? PrefixStatus { get; set; }

    [Column("prefix_description")]
    public string? PrefixDescription { get; set; }
}

/// <summary>A skill modified/enabled by a <see cref="TraitEntity"/>.</summary>
[Table("trait_skills")]
public class TraitSkillEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("trait_id")]
    public int TraitId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }
}

/// <summary>
/// A base-only fact entry (text/icon/type, no further subtype fields) on a <see cref="TraitSkillEntity"/>.
/// Unlike <see cref="TraitEntity"/>'s own facts, <c>TraitSkill.Facts</c> is typed directly as
/// <c>TraitFact[]</c> on the model (not a raw polymorphic JsonElement), so there's nothing beyond the
/// base fields to persist here. Carries (TraitId, SkillId) down directly rather than referencing
/// <see cref="TraitSkillEntity"/>'s surrogate id, consistent with the rest of the project.
/// </summary>
[Table("trait_skill_facts")]
public class TraitSkillFactEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("trait_id")]
    public int TraitId { get; set; }

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
}
