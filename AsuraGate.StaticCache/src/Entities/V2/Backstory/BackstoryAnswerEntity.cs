using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Backstory;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Backstory.BackstoryAnswer"/>.
/// </summary>
[Table("backstory_answers")]
public class BackstoryAnswerEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("journal")]
    public string Journal { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("question")]
    public int Question { get; set; }
}

/// <summary>Profession a <see cref="BackstoryAnswerEntity"/> is available to.</summary>
[Table("backstory_answer_professions")]
public class BackstoryAnswerProfessionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("backstory_answer_id")]
    public string BackstoryAnswerId { get; set; } = string.Empty;

    [NotNull]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;
}

/// <summary>Race a <see cref="BackstoryAnswerEntity"/> is available to.</summary>
[Table("backstory_answer_races")]
public class BackstoryAnswerRaceEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("backstory_answer_id")]
    public string BackstoryAnswerId { get; set; } = string.Empty;

    [NotNull]
    [Column("race")]
    public string Race { get; set; } = string.Empty;
}
