using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMailCarrierRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<int>, AccountMailCarrierSnapshotEntity>(
        database, AccountMailCarrierMapper.ToEntity, AccountMailCarrierMapper.ToModel);
