using SQLite;

namespace AsuraGate.Spec.Entities.V2.Characters;

/// <summary>
/// A crafting discipline entry for a character - <see cref="AsuraGate.Spec.Models.V2.Characters.CharacterCrafting"/>
/// has no character name of its own; callers must supply <see cref="CharacterName"/>.
/// </summary>
[Table("character_crafting_disciplines")]
public class CharacterCraftingDisciplineEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("character_name")]
    public string CharacterName { get; set; } = string.Empty;

    [NotNull]
    [Column("discipline")]
    public string Discipline { get; set; } = string.Empty;

    [NotNull]
    [Column("rating")]
    public int Rating { get; set; }

    [NotNull]
    [Column("active")]
    public bool Active { get; set; }
}
