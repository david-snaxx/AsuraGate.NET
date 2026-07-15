using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Account;

[Table("account_masteries")]
public class AccountMasteryEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
