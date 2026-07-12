using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountLuck"/>. This is an account-wide
/// singleton (the model's own <c>Id</c> is always the literal string "luck") - callers must supply
/// <see cref="AccountId"/> as the real key.
/// </summary>
[Table("account_luck")]
public class AccountLuckEntity
{
    [PrimaryKey]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("value")]
    public int Value { get; set; }
}
