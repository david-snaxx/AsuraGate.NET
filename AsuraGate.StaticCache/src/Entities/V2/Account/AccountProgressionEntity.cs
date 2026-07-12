using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountProgression"/>. Callers must
/// supply <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_progressions")]
public class AccountProgressionEntity
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
    [Column("progression_id")]
    public string ProgressionId { get; set; } = string.Empty;

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
