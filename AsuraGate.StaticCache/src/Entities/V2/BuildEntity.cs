using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Build"/>.
/// </summary>
[Table("builds")]
public class BuildEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }
}
