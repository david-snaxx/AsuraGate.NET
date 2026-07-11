using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementGroup"/>.
/// </summary>
[Table("achievement_groups")]
public class AchievementGroupEntity
{
    [PrimaryKey, Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }
}

/// <summary>Achievement categories belonging to an <see cref="AchievementGroupEntity"/>.</summary>
[Table("achievement_group_categories")]
public class AchievementGroupCategoryEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_group_id")]
    public string AchievementGroupId { get; set; } = string.Empty; // FK to AchievementGroupEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("category_id")]
    public int CategoryId { get; set; } // FK to AchievementCategoryEntity
}
