using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Legend"/>.
/// </summary>
[Table("legends")]
public class LegendEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [Indexed, Column("code")]
    public int? Code { get; set; }

    [NotNull, Indexed, Column("swap")]
    public int Swap { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("heal")]
    public int Heal { get; set; } // FK to SkillEntity

    [NotNull, Indexed, Column("elite")]
    public int Elite { get; set; } // FK to SkillEntity
}

/// <summary>Utility skills available to a <see cref="LegendEntity"/>.</summary>
[Table("legend_utilities")]
public class LegendUtilityEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("legend_id")]
    public string LegendId { get; set; } = string.Empty; // FK to LegendEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity
}
