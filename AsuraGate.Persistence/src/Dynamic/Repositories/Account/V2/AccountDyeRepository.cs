using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountDyeRepository : SnapshotRepository<IEnumerable<int>, AccountDyeSnapshotEntity>
{
    public AccountDyeRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountDyeMapper.ToEntity, AccountDyeMapper.ToModel)
    {
    }
}
