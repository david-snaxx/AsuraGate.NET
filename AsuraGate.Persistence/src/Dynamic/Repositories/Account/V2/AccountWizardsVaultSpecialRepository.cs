using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountWizardsVaultSpecialRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<AccountWizardsVaultSpecial, AccountWizardsVaultSpecialSnapshotEntity>(database);
