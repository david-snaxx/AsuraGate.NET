using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.HomeCat"/>.
/// </summary>
[Table("home_cats")]
public class HomeCatEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("hint")]
    public string Hint { get; set; } = string.Empty;
}
