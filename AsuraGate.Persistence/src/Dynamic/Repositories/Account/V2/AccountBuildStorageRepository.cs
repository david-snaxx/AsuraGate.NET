using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountBuildStorageRepository : SnapshotRepository<IEnumerable<AccountBuildStorageTemplate>, AccountBuildStorageSnapshotEntity>
{
    public AccountBuildStorageRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountBuildStorageMapper.ToEntity, AccountBuildStorageMapper.ToModel)
    {
    }
}
