using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2;

[Table("continents")]
public class ContinentEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
