using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Trait"/>.
/// </summary>
[Table("traits")]
public class TraitEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [NotNull, Indexed, Column("specialization_id")]
    public int SpecializationId { get; set; } // FK to SpecializationEntity

    [NotNull, Indexed, Column("tier")]
    public int Tier { get; set; }

    [NotNull, Column("order")]
    public int Order { get; set; }

    [NotNull, Indexed, Column("slot")]
    public string Slot { get; set; } = string.Empty; // "Minor" or "Major"
}

/// <summary>A skill that a <see cref="TraitEntity"/> modifies or enables.</summary>
[Table("trait_skills")]
public class TraitSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_trait_skills_trait_id_skill_id", Order = 1, Unique = true)]
    [Column("trait_id")]
    public int TraitId { get; set; } // FK to TraitEntity

    [NotNull]
    [Indexed(Name = "ux_trait_skills_trait_id_skill_id", Order = 2, Unique = true)]
    [Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity, api "id" value

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }
}

/// <summary>
/// A single tooltip fact belonging to either a <see cref="TraitEntity"/> directly (<see cref="TraitId"/> set) or
/// a <see cref="TraitSkillEntity"/> (<see cref="TraitSkillId"/> set) — exactly one of the two is populated.
/// One table covers every <c>TraitFact</c> subtype; only the columns relevant to <see cref="FactType"/> are populated.
/// </summary>
[Table("trait_facts")]
public class TraitFactEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [Indexed, Column("trait_id")]
    public int? TraitId { get; set; } // FK to TraitEntity; set when this fact belongs to the trait directly

    [Indexed, Column("trait_skill_id")]
    public int? TraitSkillId { get; set; } // FK to TraitSkillEntity; set when this fact belongs to a nested skill

    [NotNull, Indexed, Column("kind")]
    public string Kind { get; set; } = string.Empty; // "Base" or "Traited"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("text")]
    public string? Text { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Indexed, Column("fact_type")]
    public string? FactType { get; set; }

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

    // Buff.Duration / PrefixedBuff.Duration / Time.Duration
    [Column("duration")]
    public int? Duration { get; set; }

    // BuffConversion.Source / Percent / Target
    [Column("conversion_source")] public string? ConversionSource { get; set; }
    [Column("conversion_percent")] public string? ConversionPercent { get; set; }
    [Column("conversion_target")] public string? ConversionTarget { get; set; }

    // ComboField.FieldType
    [Column("field_type")]
    public string? FieldType { get; set; }

    // ComboFinisher.FinisherType
    [Column("finisher_type")]
    public string? FinisherType { get; set; }

    // ComboFinisher.Percent / Percent.Percent
    [Column("percent")]
    public int? Percent { get; set; }

    // Damage.HitCount
    [Column("hit_count")]
    public int? HitCount { get; set; }

    // Distance.Distance / Radius.Distance
    [Column("distance")]
    public int? Distance { get; set; }

    // Unblockable.Value
    [Column("bool_value")]
    public bool? BoolValue { get; set; }

    // PrefixedBuff.Prefix.*
    [Column("prefix_text")] public string? PrefixText { get; set; }
    [Column("prefix_icon")] public string? PrefixIcon { get; set; }
    [Column("prefix_status")] public string? PrefixStatus { get; set; }
    [Column("prefix_description")] public string? PrefixDescription { get; set; }
}
