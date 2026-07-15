using SQLite;
using AsuraGate.Persistence.Entities;

namespace AsuraGate.Persistence.Entities.V2;

[Table("skins")]
public class SkinEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
