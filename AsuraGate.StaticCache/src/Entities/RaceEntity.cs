using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Race"/>.
/// </summary>
[Table("races")]
public class RaceEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;
}

/// <summary>Racial skills available to a <see cref="RaceEntity"/>.</summary>
[Table("race_skills")]
public class RaceSkillEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("race_id")]
    public string RaceId { get; set; } = string.Empty; // FK to RaceEntity

    [NotNull, Indexed, Column("skill_id")]
    public int SkillId { get; set; } // FK to SkillEntity
}
