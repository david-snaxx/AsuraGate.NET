using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomeCatRepository : SnapshotRepository<IEnumerable<int>, AccountHomeCatSnapshotEntity>
{
    public AccountHomeCatRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountHomeCatMapper.ToEntity, AccountHomeCatMapper.ToModel)
    {
    }
}
