using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("specializations")]
public class SpecializationEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
