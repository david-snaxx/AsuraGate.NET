using SQLite;

namespace AsuraGate.Persistence.Static.Entities.V2.Homestead;

[Table("homestead_decorations")]
public class HomesteadDecorationEntity : IIdDataEntity<int>
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
