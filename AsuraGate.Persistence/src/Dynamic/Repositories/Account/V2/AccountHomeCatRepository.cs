using AsuraGate.Persistence.Dynamic.Entities.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomeCatRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<int>, AccountHomeCatSnapshotEntity>(database, "[]");
