using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Account;

[Table("account_bank_items")]
public class AccountBankItemEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
