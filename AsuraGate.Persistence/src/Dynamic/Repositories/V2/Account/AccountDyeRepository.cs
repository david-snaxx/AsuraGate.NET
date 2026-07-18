using AsuraGate.Persistence.Dynamic.Entities.V2.Account;
using AsuraGate.Persistence.Dynamic.Mappers.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.V2.Account;

public class AccountDyeRepository : SnapshotRepository<IEnumerable<int>, AccountDyeSnapshotEntity>
{
    public AccountDyeRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountDyeMapper.ToEntity, AccountDyeMapper.ToModel)
    {
    }
}
