using SQLite;

namespace AsuraGate.Persistence.Entities.V2;

[Table("recipes")]
public class RecipeEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
