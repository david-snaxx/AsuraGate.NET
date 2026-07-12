using SQLite;

namespace AsuraGate.Spec.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Legend"/>.
/// </summary>
[Table("legends")]
public class LegendEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [Column("code")]
    public int? Code { get; set; }

    [NotNull]
    [Column("swap")]
    public int Swap { get; set; }

    [NotNull]
    [Column("heal")]
    public int Heal { get; set; }

    [NotNull]
    [Column("elite")]
    public int Elite { get; set; }
}

/// <summary>Utility skill slot within a <see cref="LegendEntity"/>.</summary>
[Table("legend_utilities")]
public class LegendUtilityEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("legend_id")]
    public string LegendId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }
}
