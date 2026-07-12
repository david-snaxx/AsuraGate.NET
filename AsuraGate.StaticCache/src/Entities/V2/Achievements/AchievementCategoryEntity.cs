using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Achievements;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementCategory"/>.
/// </summary>
[Table("achievement_categories")]
public class AchievementCategoryEntity
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
    [Column("order")]
    public int Order { get; set; }

    [NotNull]
    [Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>
/// An achievement entry within an <see cref="AchievementCategoryEntity"/>; <see cref="IsTomorrow"/>
/// distinguishes the <c>Achievements</c> list from the <c>Tomorrow</c> (rotation preview) list.
/// <see cref="HasFlags"/> tracks the model's nullable <c>Flags</c> array (null vs empty matters).
/// </summary>
[Table("achievement_category_achievements")]
public class AchievementCategoryAchievementEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [NotNull]
    [Column("is_tomorrow")]
    public bool IsTomorrow { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [Column("required_access_product")]
    public string? RequiredAccessProduct { get; set; }

    [Column("required_access_condition")]
    public string? RequiredAccessCondition { get; set; }

    [NotNull]
    [Column("has_flags")]
    public bool HasFlags { get; set; }

    [Column("level_min")]
    public int? LevelMin { get; set; }

    [Column("level_max")]
    public int? LevelMax { get; set; }
}

/// <summary>A flag on an <see cref="AchievementCategoryAchievementEntity"/>; carries (CategoryId, IsTomorrow, OrderIndex) down.</summary>
[Table("achievement_category_achievement_flags")]
public class AchievementCategoryAchievementFlagEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [NotNull]
    [Column("is_tomorrow")]
    public bool IsTomorrow { get; set; }

    [NotNull]
    [Column("achievement_order_index")]
    public int AchievementOrderIndex { get; set; }

    [NotNull]
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}
