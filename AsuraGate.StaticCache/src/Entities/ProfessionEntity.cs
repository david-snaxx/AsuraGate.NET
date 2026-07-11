using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Profession"/>.
/// </summary>
[Table("professions")]
public class ProfessionEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [Indexed, Column("code")]
    public int? Code { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Column("icon_big")]
    public string IconBig { get; set; } = string.Empty;
}

/// <summary>Specializations available to a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_specializations")]
public class ProfessionSpecializationEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("specialization_id")]
    public int SpecializationId { get; set; } // FK to SpecializationEntity
}

/// <summary>Behavior flags on a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_flags")]
public class ProfessionFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A hero point training track for a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_trainings")]
public class ProfessionTrainingEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_profession_trainings_profession_id_training_id", Order = 1, Unique = true)]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull]
    [Indexed(Name = "ux_profession_trainings_profession_id_training_id", Order = 2, Unique = true)]
    [Column("training_id")]
    public int TrainingId { get; set; } // api "id" value

    [NotNull, Indexed, Column("category")]
    public string Category { get; set; } = string.Empty;

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>A single node within a <see cref="ProfessionTrainingEntity"/> track.</summary>
[Table("profession_training_track_entries")]
public class ProfessionTrainingTrackEntryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_training_id")]
    public int ProfessionTrainingId { get; set; } // FK to ProfessionTrainingEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("cost")]
    public int Cost { get; set; }

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty; // "Skill" or "Trait"

    [Indexed, Column("skill_id")]
    public int? SkillId { get; set; } // FK to SkillEntity

    [Indexed, Column("trait_id")]
    public int? TraitId { get; set; } // FK to TraitEntity
}

/// <summary>The slot/skill details for one weapon type available to a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_weapons")]
public class ProfessionWeaponEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; } // not provided by API

    [NotNull]
    [Indexed(Name = "ux_profession_weapons_profession_id_weapon_type", Order = 1, Unique = true)]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull]
    [Indexed(Name = "ux_profession_weapons_profession_id_weapon_type", Order = 2, Unique = true)]
    [Column("weapon_type")]
    public string WeaponType { get; set; } = string.Empty; // dictionary key, e.g. "Sword"

    [Indexed, Column("specialization_id")]
    public int? SpecializationId { get; set; } // FK to SpecializationEntity; set for elite spec weapons
}

/// <summary>A behavior flag on a <see cref="ProfessionWeaponEntity"/> (e.g. "Mainhand").</summary>
[Table("profession_weapon_flags")]
public class ProfessionWeaponFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_weapon_id")]
    public int ProfessionWeaponId { get; set; } // FK to ProfessionWeaponEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A skill available on a <see cref="ProfessionWeaponEntity"/>.</summary>
[Table("profession_weapon_skills")]
public class ProfessionWeaponSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_weapon_id")]
    public int ProfessionWeaponId { get; set; } // FK to ProfessionWeaponEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [Column("offhand")]
    public string? Offhand { get; set; }

    [Indexed, Column("attunement")]
    public string? Attunement { get; set; }

    [Column("source")]
    public string? Source { get; set; }
}

/// <summary>An entry in the full skill list for a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_skills")]
public class ProfessionSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("source")]
    public string? Source { get; set; }
}

/// <summary>A [palette_id, skill_id] mapping entry for a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_skill_palettes")]
public class ProfessionSkillPaletteEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty; // FK to ProfessionEntity

    [NotNull, Indexed, Column("palette_id")]
    public int PaletteId { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity
}
