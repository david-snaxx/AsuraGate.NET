using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.AchievementCategory"/>.
/// </summary>
[Table("achievement_categories")]
public class AchievementCategoryEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Indexed, Column("order")]
    public int Order { get; set; }

    [NotNull, Column("icon")]
    public string Icon { get; set; } = string.Empty;
}

/// <summary>
/// An achievement entry within an <see cref="AchievementCategoryEntity"/>, either available today
/// (<see cref="Kind"/> = "Current") or in tomorrow's daily rotation (<see cref="Kind"/> = "Tomorrow").
/// </summary>
[Table("achievement_category_achievements")]
public class AchievementCategoryAchievementEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_category_id")]
    public int AchievementCategoryId { get; set; } // FK to AchievementCategoryEntity

    [NotNull, Indexed, Column("kind")]
    public string Kind { get; set; } = string.Empty; // "Current" or "Tomorrow"

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [Column("required_access_product")]
    public string? RequiredAccessProduct { get; set; }

    [Column("required_access_condition")]
    public string? RequiredAccessCondition { get; set; }

    // Flags is nullable (not just possibly-empty) on the model; this preserves that distinction.
    [NotNull, Column("has_flags")]
    public bool HasFlags { get; set; }

    [Column("level_min")]
    public int? LevelMin { get; set; }

    [Column("level_max")]
    public int? LevelMax { get; set; }
}

/// <summary>A game-mode flag on an <see cref="AchievementCategoryAchievementEntity"/> (e.g. "PvE", "PvP", "WvW").</summary>
[Table("achievement_category_achievement_flags")]
public class AchievementCategoryAchievementFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_category_achievement_id")]
    public int AchievementCategoryAchievementId { get; set; } // FK to AchievementCategoryAchievementEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}
