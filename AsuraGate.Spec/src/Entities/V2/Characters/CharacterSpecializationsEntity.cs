using SQLite;

namespace AsuraGate.Spec.Entities.V2.Characters;

/// <summary>
/// A specialization slot within a per-game-mode loadout for a character. Callers must supply
/// <see cref="CharacterName"/>.
/// </summary>
[Table("character_specialization_slots")]
public class CharacterSpecializationSlotEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("mode")]
    public string Mode { get; set; } = string.Empty; // "pve", "pvp", "wvw"

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("specialization_id")]
    public int? SpecializationId { get; set; }

    [NotNull]
    [Column("has_traits")]
    public bool HasTraits { get; set; }
}

/// <summary>A selected trait ID within a <see cref="CharacterSpecializationSlotEntity"/>.</summary>
[Table("character_specialization_slot_traits")]
public class CharacterSpecializationSlotTraitEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("mode")]
    public string Mode { get; set; } = string.Empty;

    [NotNull]
    [Column("slot_order_index")]
    public int SlotOrderIndex { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("trait_id")]
    public int TraitId { get; set; }
}
