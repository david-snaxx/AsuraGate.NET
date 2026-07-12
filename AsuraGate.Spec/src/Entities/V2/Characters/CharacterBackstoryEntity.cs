using SQLite;

namespace AsuraGate.Spec.Entities.V2.Characters;

/// <summary>
/// A backstory answer ID selected for a character - <see cref="AsuraGate.Spec.Models.V2.Characters.CharacterBackstory"/>
/// has no character name of its own; callers must supply <see cref="CharacterName"/>.
/// </summary>
[Table("character_backstory_ids")]
public class CharacterBackstoryIdEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("answer_id")]
    public string AnswerId { get; set; } = string.Empty;
}
