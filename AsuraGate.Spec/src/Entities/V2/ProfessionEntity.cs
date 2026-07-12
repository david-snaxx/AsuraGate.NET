using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Profession"/>.
/// </summary>
[Table("professions")]
public class ProfessionEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [Column("code")]
    public int? Code { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull]
    [Column("icon_big")]
    public string IconBig { get; set; } = string.Empty;
}

/// <summary>Specialization ID available to a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_specializations")]
public class ProfessionSpecializationEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("specialization_id")]
    public int SpecializationId { get; set; }
}

/// <summary>Behavior flag on a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_flags")]
public class ProfessionFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Full skill list entry for a <see cref="ProfessionEntity"/>.</summary>
[Table("profession_skills")]
public class ProfessionSkillEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("source")]
    public string? Source { get; set; }
}

/// <summary>One [palette_id, skill_id] pair from a <see cref="ProfessionEntity"/>'s skill palette map.</summary>
[Table("profession_skill_palettes")]
public class ProfessionSkillPaletteEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("palette_id")]
    public int PaletteId { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }
}

/// <summary>
/// Hero point training track within a <see cref="ProfessionEntity"/>. <see cref="TrainingId"/> is the
/// track's own API ID, carried down to <see cref="ProfessionTrainingTrackEntryEntity"/> directly
/// (rather than this row's surrogate key) so track entries don't need this row's DB-generated ID first.
/// </summary>
[Table("profession_trainings")]
public class ProfessionTrainingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("training_id")]
    public int TrainingId { get; set; }

    [NotNull]
    [Column("category")]
    public string Category { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}

/// <summary>Single node within a <see cref="ProfessionTrainingEntity"/> track.</summary>
[Table("profession_training_track_entries")]
public class ProfessionTrainingTrackEntryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("training_id")]
    public int TrainingId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("cost")]
    public int Cost { get; set; }

    [NotNull]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("skill_id")]
    public int? SkillId { get; set; }

    [Column("trait_id")]
    public int? TraitId { get; set; }
}

/// <summary>
/// One entry of the <c>weapons</c> dictionary on a <see cref="ProfessionEntity"/>; <see cref="WeaponType"/>
/// is the dictionary key (e.g. "Sword"), carried down to child rows the same way as a natural ID.
/// </summary>
[Table("profession_weapons")]
public class ProfessionWeaponEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Column("weapon_type")]
    public string WeaponType { get; set; } = string.Empty;

    [Column("specialization_id")]
    public int? SpecializationId { get; set; }
}

/// <summary>Weapon flag within a <see cref="ProfessionWeaponEntity"/>.</summary>
[Table("profession_weapon_flags")]
public class ProfessionWeaponFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("weapon_type")]
    public string WeaponType { get; set; } = string.Empty;

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Skill available on a <see cref="ProfessionWeaponEntity"/>.</summary>
[Table("profession_weapon_skills")]
public class ProfessionWeaponSkillEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("profession_id")]
    public string ProfessionId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("weapon_type")]
    public string WeaponType { get; set; } = string.Empty;

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }

    [NotNull]
    [Column("slot")]
    public string Slot { get; set; } = string.Empty;

    [Column("offhand")]
    public string? Offhand { get; set; }

    [Column("attunement")]
    public string? Attunement { get; set; }

    [Column("source")]
    public string? Source { get; set; }
}
