using SQLite;

namespace AsuraGate.Persistence.Entities.V2.WizardsVault;

[Table("wizards_vault_objectives")]
public class WizardsVaultObjectiveEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
