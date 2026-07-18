using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountSkinRepository : SnapshotRepository<IEnumerable<int>, AccountSkinSnapshotEntity>
{
    public AccountSkinRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountSkinMapper.ToEntity, AccountSkinMapper.ToModel)
    {
    }
}
