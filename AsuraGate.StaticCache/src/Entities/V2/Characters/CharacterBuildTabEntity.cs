using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>
/// A saved build tab for a character - <see cref="Tab"/> (the model's own one-based tab index) is the
/// natural key within a character, so callers only need to supply <see cref="CharacterName"/>.
/// <c>Build.Skills</c>/<c>AquaticSkills</c> are fixed 1:1 objects, flattened onto this row.
/// </summary>
[Table("character_build_tabs")]
public class CharacterBuildTabEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("is_active")]
    public bool IsActive { get; set; }

    [NotNull]
    [Column("build_name")]
    public string BuildName { get; set; } = string.Empty;

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

    [NotNull]
    [Column("has_pets")]
    public bool HasPets { get; set; }

    [NotNull]
    [Column("has_terrestrial_pets")]
    public bool HasTerrestrialPets { get; set; }

    [NotNull]
    [Column("has_aquatic_pets")]
    public bool HasAquaticPets { get; set; }
}

/// <summary>A specialization slot within a <see cref="CharacterBuildTabEntity"/>.</summary>
[Table("character_build_tab_specializations")]
public class CharacterBuildTabSpecializationEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("specialization_id")]
    public int? SpecializationId { get; set; }

    [NotNull]
    [Column("has_traits")]
    public bool HasTraits { get; set; }
}

/// <summary>A selected trait ID within a <see cref="CharacterBuildTabSpecializationEntity"/>.</summary>
[Table("character_build_tab_traits")]
public class CharacterBuildTabTraitEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

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

/// <summary>A utility skill slot on a <see cref="CharacterBuildTabEntity"/>; <see cref="IsAquatic"/> distinguishes Skills from AquaticSkills.</summary>
[Table("character_build_tab_utilities")]
public class CharacterBuildTabUtilityEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

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

/// <summary>A legend ID on a <see cref="CharacterBuildTabEntity"/>; <see cref="IsAquatic"/> distinguishes Legends from AquaticLegends.</summary>
[Table("character_build_tab_legends")]
public class CharacterBuildTabLegendEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

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

/// <summary>A Ranger pet selection on a <see cref="CharacterBuildTabEntity"/>; <see cref="IsAquatic"/> distinguishes Terrestrial from Aquatic.</summary>
[Table("character_build_tab_pets")]
public class CharacterBuildTabPetEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("tab")]
    public int Tab { get; set; }

    [NotNull]
    [Column("is_aquatic")]
    public bool IsAquatic { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("pet_id")]
    public int PetId { get; set; }
}
