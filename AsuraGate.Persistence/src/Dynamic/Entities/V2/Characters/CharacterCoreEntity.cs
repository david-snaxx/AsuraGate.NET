using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Characters;

[Table("character_cores")]
public class CharacterCoreEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
