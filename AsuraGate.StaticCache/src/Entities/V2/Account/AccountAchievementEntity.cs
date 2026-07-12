using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountAchievement"/>. Callers must
/// supply <see cref="AccountId"/> - not on the model. <see cref="HasBits"/> tracks the model's nullable
/// <c>Bits</c> array (null vs empty matters).
/// </summary>
[Table("account_achievements")]
public class AccountAchievementEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("done")]
    public bool Done { get; set; }

    [NotNull]
    [Column("has_bits")]
    public bool HasBits { get; set; }

    [Column("current")]
    public int? Current { get; set; }

    [Column("max")]
    public int? Max { get; set; }

    [Column("repeated")]
    public int? Repeated { get; set; }

    [Column("unlocked")]
    public bool? Unlocked { get; set; }
}

/// <summary>A completed bit index on an <see cref="AccountAchievementEntity"/>.</summary>
[Table("account_achievement_bits")]
public class AccountAchievementBitEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("achievement_id")]
    public int AchievementId { get; set; }

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("bit")]
    public int Bit { get; set; }
}
