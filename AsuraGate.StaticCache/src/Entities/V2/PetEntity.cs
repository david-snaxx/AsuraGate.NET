using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Pet"/>.
/// </summary>
[Table("pets")]
public class PetEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Skill available to a <see cref="PetEntity"/>.</summary>
[Table("pet_skills")]
public class PetSkillEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("pet_id")]
    public int PetId { get; set; }

    [NotNull]
    [Column("skill_id")]
    public int SkillId { get; set; }
}
