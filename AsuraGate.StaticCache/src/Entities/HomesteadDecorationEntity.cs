using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Homestead.HomesteadDecoration"/>.
/// </summary>
[Table("homestead_decorations")]
public class HomesteadDecorationEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("max_count")]
    public int MaxCount { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>Categories a <see cref="HomesteadDecorationEntity"/> belongs to.</summary>
[Table("homestead_decoration_category_links")]
public class HomesteadDecorationCategoryLinkEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("decoration_id")]
    public int DecorationId { get; set; } // FK to HomesteadDecorationEntity

    [NotNull, Indexed, Column("category_id")]
    public int CategoryId { get; set; } // FK to HomesteadDecorationCategoryEntity
}
