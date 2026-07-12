using SQLite;

namespace AsuraGate.StaticCache.Entities.V2;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.MaterialCategory"/>.
/// </summary>
[Table("material_categories")]
public class MaterialCategoryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }
}

/// <summary>Item ID belonging to a <see cref="MaterialCategoryEntity"/>.</summary>
[Table("material_category_items")]
public class MaterialCategoryItemEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("material_category_id")]
    public int MaterialCategoryId { get; set; }

    [NotNull]
    [Column("item_id")]
    public int ItemId { get; set; }
}
