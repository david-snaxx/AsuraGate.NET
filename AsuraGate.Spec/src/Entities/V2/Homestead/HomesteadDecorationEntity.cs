using SQLite;

namespace AsuraGate.Spec.Entities.V2.Homestead;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Homestead.HomesteadDecoration"/>.
/// </summary>
[Table("homestead_decorations")]
public class HomesteadDecorationEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("max_count")]
    public int MaxCount { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Category ID a <see cref="HomesteadDecorationEntity"/> belongs to.</summary>
[Table("homestead_decoration_categories")]
public class HomesteadDecorationCategoryLinkEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("homestead_decoration_id")]
    public int HomesteadDecorationId { get; set; }

    [NotNull]
    [Column("category_id")]
    public int CategoryId { get; set; }
}
