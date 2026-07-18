using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomeNodeRepository : SnapshotRepository<IEnumerable<string>, AccountHomeNodeSnapshotEntity>
{
    public AccountHomeNodeRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountHomeNodeMapper.ToEntity, AccountHomeNodeMapper.ToModel)
    {
    }
}
