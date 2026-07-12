using SQLite;

namespace AsuraGate.Spec.Entities.V2.Account;

/// <summary>
/// SQLite table shared by <see cref="AsuraGate.Spec.Models.V2.Account.AccountWizardsVaultDailyObjective"/>,
/// <see cref="AsuraGate.Spec.Models.V2.Account.AccountWizardsVaultWeeklyObjective"/>, and
/// <see cref="AsuraGate.Spec.Models.V2.Account.AccountWizardsVaultSpecialObjective"/> - all three are
/// identical except Special's extra nullable <c>PeriodicAcclaim</c>, so one table with a
/// <see cref="Category"/> discriminator covers all three instead of three near-duplicate tables.
/// </summary>
[Table("account_wizards_vault_objectives")]
public class AccountWizardsVaultObjectiveEntity
{
    [PrimaryKey, AutoIncrement]
    [Column("id")]
    public int Id { get; set; }

    [NotNull]
    [Indexed]
    [Column("account_id")]
    public string AccountId { get; set; } = string.Empty;

    [NotNull]
    [Indexed]
    [Column("category")]
    public string Category { get; set; } = string.Empty; // "daily", "weekly", "special"

    [NotNull]
    [Column("order_index")]
    public int OrderIndex { get; set; }

    [NotNull]
    [Column("objective_id")]
    public int ObjectiveId { get; set; }

    [NotNull]
    [Column("title")]
    public string Title { get; set; } = string.Empty;

    [NotNull]
    [Column("track")]
    public string Track { get; set; } = string.Empty;

    [NotNull]
    [Column("acclaim")]
    public int Acclaim { get; set; }

    [NotNull]
    [Column("progress_current")]
    public int ProgressCurrent { get; set; }

    [NotNull]
    [Column("progress_complete")]
    public int ProgressComplete { get; set; }

    [NotNull]
    [Column("claimed")]
    public bool Claimed { get; set; }

    [Column("periodic_acclaim")]
    public int? PeriodicAcclaim { get; set; } // Special only
}
