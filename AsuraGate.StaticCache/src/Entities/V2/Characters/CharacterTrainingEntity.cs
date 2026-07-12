using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Characters;

/// <summary>A training track progress entry for a character. Callers must supply <see cref="CharacterName"/>.</summary>
[Table("character_trainings")]
public class CharacterTrainingEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("training_id")]
    public int TrainingId { get; set; }

    [NotNull]
    [Column("spent")]
    public int Spent { get; set; }

    [NotNull]
    [Column("done")]
    public bool Done { get; set; }
}
