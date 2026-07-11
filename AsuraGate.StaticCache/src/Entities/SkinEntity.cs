using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skin"/>.
/// </summary>
[Table("skins")]
public class SkinEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }

    [NotNull, Indexed, Column("rarity")]
    public string Rarity { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }
}

/// <summary>Behavior flags on a <see cref="SkinEntity"/> (e.g. "ShowInWardrobe", "NoCost").</summary>
[Table("skin_flags")]
public class SkinFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skin_id")]
    public int SkinId { get; set; } // FK to SkinEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Race/profession restrictions on a <see cref="SkinEntity"/>.</summary>
[Table("skin_restrictions")]
public class SkinRestrictionEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skin_id")]
    public int SkinId { get; set; } // FK to SkinEntity

    [NotNull, Indexed, Column("restriction")]
    public string Restriction { get; set; } = string.Empty;
}

/// <summary>
/// Type-specific details for a <see cref="SkinEntity"/>. One row per skin; only the columns relevant to the
/// owning <see cref="SkinEntity.Type"/> (which selects the <c>SkinDetails</c> subtype) are populated.
/// </summary>
[Table("skin_details")]
public class SkinDetailsEntity
{
    [PrimaryKey, Column("skin_id")]
    public int SkinId { get; set; } // FK to SkinEntity

    // Armor slot / Weapon type / Gathering tool type
    [Indexed, Column("sub_type")]
    public string? SubType { get; set; }

    // Armor only
    [Column("weight_class")]
    public string? WeightClass { get; set; }

    // Weapon only
    [Indexed, Column("damage_type")]
    public string? DamageType { get; set; }
}

/// <summary>A per-channel default dye applied to an armor <see cref="SkinEntity"/>.</summary>
[Table("skin_dye_slot_defaults")]
public class SkinDyeSlotDefaultEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("skin_id")]
    public int SkinId { get; set; } // FK to SkinEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("color_id")]
    public int ColorId { get; set; } // FK to DyeEntity

    [NotNull, Column("material")]
    public string Material { get; set; } = string.Empty;
}
