using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Mount.MountSkin"/>.
/// </summary>
[Table("mount_skins")]
public class MountSkinEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Indexed, Column("mount")]
    public string Mount { get; set; } = string.Empty; // FK to MountTypeEntity

    [Column("mount_guid")]
    public string? MountGuid { get; set; }
}

/// <summary>A dye slot on a <see cref="MountSkinEntity"/>.</summary>
[Table("mount_skin_dye_slots")]
public class MountSkinDyeSlotEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mount_skin_id")]
    public int MountSkinId { get; set; } // FK to MountSkinEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("color_id")]
    public int ColorId { get; set; } // FK to DyeEntity

    [NotNull, Column("material")]
    public string Material { get; set; } = string.Empty;
}
