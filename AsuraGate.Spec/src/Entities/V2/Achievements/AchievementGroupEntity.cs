using SQLite;

namespace AsuraGate.Spec.Entities.V2.Achievements;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementGroup"/>.
/// </summary>
[Table("achievement_groups")]
public class AchievementGroupEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull]
    [Column("order")]
    public int Order { get; set; }
}

/// <summary>A category ID belonging to an <see cref="AchievementGroupEntity"/>.</summary>
[Table("achievement_group_categories")]
public class AchievementGroupCategoryEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("achievement_group_id")]
    public string AchievementGroupId { get; set; } = string.Empty;

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("category_id")]
    public int CategoryId { get; set; }
}
