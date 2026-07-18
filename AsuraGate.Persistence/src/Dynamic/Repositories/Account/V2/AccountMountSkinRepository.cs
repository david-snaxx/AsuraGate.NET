using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMountSkinRepository : SnapshotRepository<IEnumerable<int>, AccountMountSkinSnapshotEntity>
{
    public AccountMountSkinRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountMountSkinMapper.ToEntity, AccountMountSkinMapper.ToModel)
    {
    }
}
