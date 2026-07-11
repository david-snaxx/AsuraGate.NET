using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Specialization"/>.
/// </summary>
[Table("specializations")]
public class SpecializationEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Indexed, Column("profession")]
    public string Profession { get; set; } = string.Empty;

    [NotNull, Indexed, Column("elite")]
    public bool Elite { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [Column("profession_icon")]
    public string? ProfessionIcon { get; set; }

    [Column("profession_icon_big")]
    public string? ProfessionIconBig { get; set; }

    [NotNull, Column("background")]
    public string Background { get; set; } = string.Empty;

    [Indexed, Column("weapon_trait")]
    public int? WeaponTrait { get; set; } // FK to TraitEntity
}

/// <summary>A trait slotted into a <see cref="SpecializationEntity"/>, either minor (fixed) or major (selectable).</summary>
[Table("specialization_traits")]
public class SpecializationTraitEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("specialization_id")]
    public int SpecializationId { get; set; } // FK to SpecializationEntity

    [NotNull, Indexed, Column("slot")]
    public string Slot { get; set; } = string.Empty; // "Minor" or "Major"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("trait_id")]
    public int TraitId { get; set; } // FK to TraitEntity
}
