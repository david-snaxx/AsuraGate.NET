using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Skin"/>.
/// </summary>
[Table("skins")]
public class SkinEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("icon")]
    public string? Icon { get; set; }

    [NotNull]
    [Indexed]
    [Column("rarity")]
    public string Rarity { get; set; } = string.Empty;

    [Column("description")]
    public string? Description { get; set; }
}

/// <summary>Behavior flag on a <see cref="SkinEntity"/>.</summary>
[Table("skin_flags")]
public class SkinFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skin_id")]
    public int SkinId { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>Race/profession restriction on a <see cref="SkinEntity"/>.</summary>
[Table("skin_restrictions")]
public class SkinRestrictionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skin_id")]
    public int SkinId { get; set; }

    [NotNull]
    [Column("restriction")]
    public string Restriction { get; set; } = string.Empty;
}

/// <summary>
/// Type-specific details for a <see cref="SkinEntity"/> (union of the 4 <c>SkinDetails</c> subtypes),
/// same discriminator-table idea as <c>ItemDetailsEntity</c>. <see cref="HasDyeSlots"/> and
/// <see cref="HasDefaultDyeSlots"/> track the two independently-nullable levels of the armor dye slot
/// data (the <c>SkinDyeSlot</c> object itself, and its <c>Default</c> array).
/// </summary>
[Table("skin_details")]
public class SkinDetailsEntity
{
    [PrimaryKey]
    [Column("skin_id")]
    public int SkinId { get; set; }

    [Column("details_subtype")]
    public string? DetailsSubtype { get; set; } // Armor slot / Weapon type / Gathering type

    [Column("weight_class")]
    public string? WeightClass { get; set; } // Armor

    [Column("damage_type")]
    public string? DamageType { get; set; } // Weapon

    [NotNull]
    [Column("has_dye_slots")]
    public bool HasDyeSlots { get; set; } // Armor

    [NotNull]
    [Column("has_default_dye_slots")]
    public bool HasDefaultDyeSlots { get; set; } // Armor
}

/// <summary>A default dye channel entry within a <see cref="SkinDetailsEntity"/>'s armor dye slots.</summary>
[Table("skin_default_dye_slots")]
public class SkinDefaultDyeSlotEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("skin_id")]
    public int SkinId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("color_id")]
    public int ColorId { get; set; }

    [NotNull]
    [Column("material")]
    public string Material { get; set; } = string.Empty;
}
