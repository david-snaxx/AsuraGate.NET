using SQLite;

namespace AsuraGate.Persistence.Entities.V2.Account;

[Table("account_wizards_vault_daily_objectives")]
public class AccountWizardsVaultDailyObjectiveEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
