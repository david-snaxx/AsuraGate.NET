using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountBuildStorageTemplate"/>. Callers
/// must supply <see cref="AccountId"/> - not on the model, and the model has no id of its own (only a
/// display name), so <see cref="OrderIndex"/> (array position) is the real identity. <c>Skills</c> and
/// <c>AquaticSkills</c> are fixed 1:1 objects, flattened onto this row.
/// </summary>
[Table("account_build_storage_templates")]
public class AccountBuildStorageTemplateEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [Column("skills_heal")]
    public int? SkillsHeal { get; set; }

    [Column("skills_elite")]
    public int? SkillsElite { get; set; }

    [NotNull]
    [Column("has_skills_utilities")]
    public bool HasSkillsUtilities { get; set; }

    [Column("aquatic_skills_heal")]
    public int? AquaticSkillsHeal { get; set; }

    [Column("aquatic_skills_elite")]
    public int? AquaticSkillsElite { get; set; }

    [NotNull]
    [Column("has_aquatic_skills_utilities")]
    public bool HasAquaticSkillsUtilities { get; set; }

    [NotNull]
    [Column("has_legends")]
    public bool HasLegends { get; set; }

    [NotNull]
    [Column("has_aquatic_legends")]
    public bool HasAquaticLegends { get; set; }
}

/// <summary>A specialization slot within an <see cref="AccountBuildStorageTemplateEntity"/>.</summary>
[Table("account_build_storage_template_specializations")]
public class AccountBuildStorageTemplateSpecializationEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("template_order_index")]
    public int TemplateOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("specialization_id")]
    public int? SpecializationId { get; set; }

    [NotNull]
    [Column("has_traits")]
    public bool HasTraits { get; set; }
}

/// <summary>A selected trait ID within an <see cref="AccountBuildStorageTemplateSpecializationEntity"/>.</summary>
[Table("account_build_storage_template_traits")]
public class AccountBuildStorageTemplateTraitEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("template_order_index")]
    public int TemplateOrderIndex { get; set; }

    [NotNull]
    [Column("specialization_order_index")]
    public int SpecializationOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("trait_id")]
    public int TraitId { get; set; }
}

/// <summary>A utility skill slot on an <see cref="AccountBuildStorageTemplateEntity"/>; <see cref="IsAquatic"/> distinguishes Skills from AquaticSkills.</summary>
[Table("account_build_storage_template_utilities")]
public class AccountBuildStorageTemplateUtilityEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("template_order_index")]
    public int TemplateOrderIndex { get; set; }

    [NotNull]
    [Column("is_aquatic")]
    public bool IsAquatic { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }
}

/// <summary>A legend ID on an <see cref="AccountBuildStorageTemplateEntity"/>; <see cref="IsAquatic"/> distinguishes Legends from AquaticLegends.</summary>
[Table("account_build_storage_template_legends")]
public class AccountBuildStorageTemplateLegendEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("template_order_index")]
    public int TemplateOrderIndex { get; set; }

    [NotNull]
    [Column("is_aquatic")]
    public bool IsAquatic { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("legend_id")]
    public string LegendId { get; set; } = string.Empty;
}
