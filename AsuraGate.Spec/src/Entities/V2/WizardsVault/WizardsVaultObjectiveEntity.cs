using SQLite;

namespace AsuraGate.Spec.Entities.V2.WizardsVault;

/// <summary>
/// SQLite table for <see cref="AsuraGate.Spec.Models.V2.WizardsVault.WizardsVaultObjective"/>.
/// </summary>
[Table("wizards_vault_objectives")]
public class WizardsVaultObjectiveEntity
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("track")]
    public string Track { get; set; } = string.Empty;

    [NotNull]
    [Column("acclaim")]
    public int Acclaim { get; set; }
}
