using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountTitleRepository : SnapshotRepository<IEnumerable<int>, AccountTitleSnapshotEntity>
{
    public AccountTitleRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountTitleMapper.ToEntity, AccountTitleMapper.ToModel)
    {
    }
}
