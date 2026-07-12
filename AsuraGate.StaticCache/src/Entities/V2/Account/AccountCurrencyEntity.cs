using SQLite;

namespace AsuraGate.StaticCache.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountCurrency"/>. Account-scoped list
/// item with no account id on the model - callers must supply <see cref="AccountId"/>.
/// </summary>
[Table("account_currencies")]
public class AccountCurrencyEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("currency_id")]
    public int CurrencyId { get; set; }

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
