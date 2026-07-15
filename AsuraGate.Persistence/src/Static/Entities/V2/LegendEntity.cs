using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2;

[Table("legends")]
public class LegendEntity : IIdDataEntity<string>
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
