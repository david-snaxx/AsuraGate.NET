using AsuraGate.Persistence.Dynamic.Entities.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountJadeBotRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<int>, AccountJadeBotSnapshotEntity>(database, "[]");
