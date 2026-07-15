using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("material_categories")]
public class MaterialCategoryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
