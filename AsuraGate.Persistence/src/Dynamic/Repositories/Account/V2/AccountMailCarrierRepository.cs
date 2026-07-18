using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMailCarrierRepository : SnapshotRepository<IEnumerable<int>, AccountMailCarrierSnapshotEntity>
{
    public AccountMailCarrierRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountMailCarrierMapper.ToEntity, AccountMailCarrierMapper.ToModel)
    {
    }
}
