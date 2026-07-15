using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2;

[Table("dungeons")]
public class DungeonEntity : IIdDataEntity<string>
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
