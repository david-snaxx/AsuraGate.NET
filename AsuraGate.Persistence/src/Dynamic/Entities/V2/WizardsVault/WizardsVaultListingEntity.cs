using SQLite;

namespace AsuraGate.Persistence.Entities.V2.WizardsVault;

[Table("wizards_vault_listings")]
public class WizardsVaultListingEntity
{
    [PrimaryKey]
    [Column("id")]
    public string Id { get; set; } = string.Empty;

    [NotNull]
    [Column("data")]
    public string Data { get; set; } = string.Empty;
}
