using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountNoveltyRepository : SnapshotRepository<IEnumerable<int>, AccountNoveltySnapshotEntity>
{
    public AccountNoveltyRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountNoveltyMapper.ToEntity, AccountNoveltyMapper.ToModel)
    {
    }
}
