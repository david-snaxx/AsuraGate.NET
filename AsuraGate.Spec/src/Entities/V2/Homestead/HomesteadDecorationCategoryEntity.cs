using SQLite;

namespace AsuraGate.Spec.Entities.V2.Homestead;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Homestead.HomesteadDecorationCategory"/>.
/// </summary>
[Table("homestead_decoration_category")]
public class HomesteadDecorationCategoryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
}
