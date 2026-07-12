using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountFinisher"/>. Callers must supply
/// <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_finishers")]
public class AccountFinisherEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("finisher_id")]
    public int FinisherId { get; set; }

    [NotNull]
    [Column("permanent")]
    public bool Permanent { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }
}
