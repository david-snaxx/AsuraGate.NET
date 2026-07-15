using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Homestead;

[Table("homestead_decorations")]
public class HomesteadDecorationEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
