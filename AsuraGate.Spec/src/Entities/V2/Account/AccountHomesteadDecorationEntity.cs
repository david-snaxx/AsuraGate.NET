using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.Account.AccountHomesteadDecoration"/>. Callers
/// must supply <see cref="AccountId"/> - not on the model.
/// </summary>
[Table("account_homestead_decorations")]
public class AccountHomesteadDecorationEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Column("decoration_id")]
    public int DecorationId { get; set; }

    [NotNull]
    [Column("count")]
    public int Count { get; set; }
}
