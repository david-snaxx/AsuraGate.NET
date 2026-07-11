using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Mount.MountType"/>.
/// </summary>
[Table("mount_types")]
public class MountTypeEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("default_skin")]
    public int DefaultSkin { get; set; } // FK to MountSkinEntity

    [Column("guid")]
    public string? Guid { get; set; }
}

/// <summary>A skin available for a <see cref="MountTypeEntity"/>.</summary>
[Table("mount_type_skins")]
public class MountTypeSkinEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mount_type_id")]
    public string MountTypeId { get; set; } = string.Empty; // FK to MountTypeEntity

    [NotNull, Indexed, Column("skin_id")]
    public int SkinId { get; set; } // FK to MountSkinEntity
}

/// <summary>A skill slot on a <see cref="MountTypeEntity"/>.</summary>
[Table("mount_type_skills")]
public class MountTypeSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mount_type_id")]
    public string MountTypeId { get; set; } = string.Empty; // FK to MountTypeEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity

    [NotNull, Column("slot")]
    public string Slot { get; set; } = string.Empty;
}
