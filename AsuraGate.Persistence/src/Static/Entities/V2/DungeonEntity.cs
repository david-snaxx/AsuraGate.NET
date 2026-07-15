using SQLite;
using AsuraGate.Persistence.Entities;

namespace AsuraGate.Persistence.Entities.V2;

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
