using SQLite;

namespace AsuraGate.Spec.Entities.V2.Achievements;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement"/>.
/// </summary>
[Table( "achievements")]
public class AchievementEntity
{
    [PrimaryKey] 
    [Column("id")]
    public int Id { get; set; }
    
    [Column("icon")]
    public string? Icon { get; set; } = string.Empty;
    
    [NotNull]
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    
    [NotNull]
    [Column("description")]
    public string Description { get; set; } = string.Empty;
    
    [NotNull]
    [Column("requirement")]
    public string Requirement { get; set; } = string.Empty;
    
    [NotNull]
    [Column("locked_text")]
    public string LockedText { get; set; } = string.Empty;
    
    [NotNull]
    [Indexed]
    [Column("type")]
    public string Type { get; set; } = string.Empty;

    [Column("point_cap")]
    public int? PointCap { get; set; }

    // bool flag for AchievementFlagEntity
    [NotNull] 
    [Column("has_flags")]
    public bool HasFlags { get; set; }

    // bool flag for AchievementTierEntity
    [NotNull]
    [Column("has_tiers")]
    public bool HasTiers { get; set; }

    // bool flag for AchievementPrerequisiteEntity
    [NotNull]
    [Column("has_prerequisites")]
    public bool HasPrerequisites { get; set; }

    // bool flag for AchievementRewardEntity
    [NotNull] 
    [Column("has_rewards")]
    public bool HasRewards { get; set; }

    // bool flag for AchievementBitEntity
    [NotNull] 
    [Column("has_bits")]
    public bool HasBits { get; set; }
}

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement.Flags"/>.
/// </summary>
[Table( "achievement_flags")]
public class AchievementFlagEntity
{
    [PrimaryKey] 
    [AutoIncrement] 
    [Column("id")]
    public int Id { get; set; }
    
    // FK to AchievementEntity
    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    
    [Column("flag")]
    public string Flag { get; set; } = string.Empty;
}

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement.Tiers"/>.
/// </summary>
[Table( "achievement_tiers")]
public class AchievementTierEntity
{
    [PrimaryKey] 
    [AutoIncrement] 
    [Column("id")]
    public int Id { get; set; }
    
    // FK to AchievementEntity
    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }

    [NotNull]
    [Column("points")]
    public int Points { get; set; }
}

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement.Prerequisites"/>.
/// </summary>
[Table( "achievement_prerequisites")]
public class AchievementPrerequisiteEntity
{
    [PrimaryKey] 
    [AutoIncrement] 
    [Column("id")]
    public int Id { get; set; }
    
    // FK to AchievementEntity
    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }
    
    [Column("prerequisite_achievement_id")]
    [Indexed]
    public int PrerequisiteAchievementId { get; set; }
}

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement.Rewards"/>.
/// </summary>
[Table( "achievement_rewards")]
public class AchievementRewardEntity
{
    [PrimaryKey] 
    [AutoIncrement] 
    [Column("id")]
    public int Id { get; set; }
    
    // FK to AchievementEntity
    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column ("type")]
    public string? Type { get; set; } = string.Empty;

    [Column("item_id")]
    [Indexed]
    public int? ItemId { get; set; }
    
    [Column("count")]
    public int? Count { get; set; }
    
    [Column("region")]
    public string? Region { get; set; }
}

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Achievements.Achievement.Bits"/>.
/// </summary>
[Table( "achievement_bits")]
public class AchievementBitEntity
{
    [PrimaryKey] 
    [AutoIncrement] 
    [Column("id")]
    public int Id { get; set; }
    
    // FK to AchievementEntity
    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [Column("type")]
    public string? Type { get; set; } = string.Empty;

    [Column("type_object_id")]
    [Indexed]
    public int? TypeObjectId { get; set; }
    
    [Column("text")]
    public string? Text { get; set; }
}