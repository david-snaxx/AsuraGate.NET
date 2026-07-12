using SQLite;

namespace AsuraGate.Spec.Entities.V2.Backstory;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Backstory.BackstoryQuestion"/>.
/// </summary>
[Table("backstory_questions")]
public class BackstoryQuestionEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }
}

/// <summary>Answer ID available for a <see cref="BackstoryQuestionEntity"/>.</summary>
[Table("backstory_question_answers")]
public class BackstoryQuestionAnswerEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("backstory_question_id")]
    public int BackstoryQuestionId { get; set; }

    [NotNull]
    [Column("answer_id")]
    public string AnswerId { get; set; } = string.Empty;
}

/// <summary>Race a <see cref="BackstoryQuestionEntity"/> applies to.</summary>
[Table("backstory_question_races")]
public class BackstoryQuestionRaceEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("backstory_question_id")]
    public int BackstoryQuestionId { get; set; }

    [NotNull]
    [Column("race")]
    public string Race { get; set; } = string.Empty;
}

/// <summary>Profession a <see cref="BackstoryQuestionEntity"/> applies to.</summary>
[Table("backstory_question_professions")]
public class BackstoryQuestionProfessionEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("backstory_question_id")]
    public int BackstoryQuestionId { get; set; }

    [NotNull]
    [Column("profession")]
    public string Profession { get; set; } = string.Empty;
}
