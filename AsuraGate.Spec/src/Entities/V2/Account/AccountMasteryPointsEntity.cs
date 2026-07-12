using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountMasteryPoints"/> - a singleton
/// per account (no id on the model), so this row's PK is <see cref="AccountId"/> directly.
/// </summary>
[Table("account_mastery_points")]
public class AccountMasteryPointsEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;
}

/// <summary>Per-region mastery point total within an <see cref="AccountMasteryPointsEntity"/>.</summary>
[Table("account_mastery_point_totals")]
public class AccountMasteryPointTotalEntity
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
    [Column("region")]
    public string Region { get; set; } = string.Empty;

    [NotNull]
    [Column("spent")]
    public int Spent { get; set; }

    [NotNull]
    [Column("earned")]
    public int Earned { get; set; }
}

/// <summary>An unlocked mastery point within an <see cref="AccountMasteryPointsEntity"/>.</summary>
[Table("account_mastery_point_unlocked")]
public class AccountMasteryPointUnlockedEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("mastery_point_id")]
    public int MasteryPointId { get; set; }

    [NotNull]
    [Column("region")]
    public string Region { get; set; } = string.Empty;
}
