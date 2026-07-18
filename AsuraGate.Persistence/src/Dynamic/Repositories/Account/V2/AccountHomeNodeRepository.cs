using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomeNodeRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<string>, AccountHomeNodeSnapshotEntity>(
        database, AccountHomeNodeMapper.ToEntity, AccountHomeNodeMapper.ToModel);
