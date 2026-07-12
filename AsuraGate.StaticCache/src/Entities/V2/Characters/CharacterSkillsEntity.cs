using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>
/// A per-game-mode skill loadout for a character (one row per pve/pvp/wvw). Callers must supply
/// <see cref="CharacterName"/>.
/// </summary>
[Table("character_skill_loadouts")]
public class CharacterSkillLoadoutEntity
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

    [Column("heal")]
    public int? Heal { get; set; }

    [NotNull]
    [Column("has_utilities")]
    public bool HasUtilities { get; set; }

    [Column("elite")]
    public int? Elite { get; set; }

    [NotNull]
    [Column("has_legends")]
    public bool HasLegends { get; set; }
}

/// <summary>A utility skill slot within a <see cref="CharacterSkillLoadoutEntity"/>.</summary>
[Table("character_skill_utilities")]
public class CharacterSkillUtilityEntity
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
    public string Mode { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }
}

/// <summary>A Revenant legend within a <see cref="CharacterSkillLoadoutEntity"/>.</summary>
[Table("character_skill_legends")]
public class CharacterSkillLegendEntity
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
    public string Mode { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("legend_id")]
    public string LegendId { get; set; } = string.Empty;
}
