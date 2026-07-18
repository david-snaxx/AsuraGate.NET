using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMasteryPointsRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<AccountMasteryPoints, AccountMasteryPointsSnapshotEntity>(database);
