using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountSkiffRepository : SnapshotRepository<IEnumerable<int>, AccountSkiffSnapshotEntity>
{
    public AccountSkiffRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountSkiffMapper.ToEntity, AccountSkiffMapper.ToModel)
    {
    }
}
