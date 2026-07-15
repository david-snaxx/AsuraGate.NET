using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2;

[Table("api_files")]
public class ApiFileEntity : IIdDataEntity<string>
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
