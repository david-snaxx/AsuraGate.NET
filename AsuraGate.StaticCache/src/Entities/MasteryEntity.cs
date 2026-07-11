using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Mastery"/>.
/// </summary>
[Table("masteries")]
public class MasteryEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("requirement")]
    public string Requirement { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }

    [NotNull, Column("background")]
    public string Background { get; set; } = string.Empty;

    [NotNull, Indexed, Column("region")]
    public string Region { get; set; } = string.Empty;
}

/// <summary>A single level within a <see cref="MasteryEntity"/> track.</summary>
[Table("mastery_levels")]
public class MasteryLevelEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("mastery_id")]
    public int MasteryId { get; set; } // FK to MasteryEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("instruction")]
    public string Instruction { get; set; } = string.Empty;

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;

    [NotNull, Column("point_cost")]
    public int PointCost { get; set; }

    [NotNull, Column("exp_cost")]
    public int ExpCost { get; set; }
}
