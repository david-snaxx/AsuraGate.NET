using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Homestead.HomesteadDecorationCategory"/>.
/// </summary>
[Table("homestead_decoration_categories")]
public class HomesteadDecorationCategoryEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;
}
