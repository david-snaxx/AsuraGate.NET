using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("emotes")]
public class EmoteEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
