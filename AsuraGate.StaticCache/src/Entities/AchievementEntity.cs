using SQLite;

namespace AsuraGate.StaticCache.Entities;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement"/>.
/// </summary>
[Table("achievements")]
public class AchievementEntity
{
    [PrimaryKey, Column("id")]
    public int Id { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [NotNull, Indexed, Column("name")]
    public string Name { get; set; } = string.Empty;

    [NotNull, Column("description")]
    public string Description { get; set; } = string.Empty;

    [NotNull, Column("requirement")]
    public string Requirement { get; set; } = string.Empty;

    [NotNull, Column("locked_text")]
    public string LockedText { get; set; } = string.Empty;

    [NotNull, Indexed, Column("type")]
    public string Type { get; set; } = string.Empty;

    [Indexed, Column("point_cap")]
    public int? PointCap { get; set; }

    // Bits is nullable (not just possibly-empty) on the model; this preserves that distinction since a child
    // table can't otherwise tell "explicitly empty" apart from "not applicable".
    [NotNull, Column("has_bits")]
    public bool HasBits { get; set; }
}

/// <summary>Behavior flags on an <see cref="AchievementEntity"/> (e.g. "Daily", "Repeatable", "Hidden").</summary>
[Table("achievement_flags")]
public class AchievementFlagEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Indexed, Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>A completion tier within an <see cref="AchievementEntity"/>.</summary>
[Table("achievement_tiers")]
public class AchievementTierEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Column("count")]
    public int Count { get; set; }

    [NotNull, Column("points")]
    public int Points { get; set; }
}

/// <summary>An achievement that must be completed before an <see cref="AchievementEntity"/> unlocks.</summary>
[Table("achievement_prerequisites")]
public class AchievementPrerequisiteEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Indexed, Column("prerequisite_achievement_id")]
    public int PrerequisiteAchievementId { get; set; } // FK to AchievementEntity
}

/// <summary>A reward granted upon completing an <see cref="AchievementEntity"/>; covers all four reward subtypes.</summary>
[Table("achievement_rewards")]
public class AchievementRewardEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull, Indexed, Column("reward_type")]
    public string RewardType { get; set; } = string.Empty; // "Coins", "Item", "Mastery", "Title"

    // Coins.Count / Item.Count
    [Column("count")]
    public int? Count { get; set; }

    // Item.Id / Mastery.Id / Title.Id (meaning depends on RewardType)
    [Indexed, Column("ref_id")]
    public int? RefId { get; set; }

    // Mastery.Region
    [Column("region")]
    public string? Region { get; set; }
}

/// <summary>A discrete collectible or step entry within an <see cref="AchievementEntity"/>'s bit-based progress.</summary>
[Table("achievement_bits")]
public class AchievementBitEntity
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [NotNull, Indexed, Column("achievement_id")]
    public int AchievementId { get; set; } // FK to AchievementEntity

    [NotNull, Column("order_index")]
    public int OrderIndex { get; set; }

    [Indexed, Column("type")]
    public string? Type { get; set; } // "Text", "Item", "Minipet", "Skin"

    [Column("ref_id")]
    public int? RefId { get; set; }

    [Column("text")]
    public string? Text { get; set; }
}
