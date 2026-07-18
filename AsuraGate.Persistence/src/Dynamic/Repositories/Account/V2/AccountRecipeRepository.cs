using AsuraGate.Persistence.Dynamic.Entities.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountRecipeRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<int>, AccountRecipeSnapshotEntity>(database, "[]");
