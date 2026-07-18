using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMountTypeRepository : SnapshotRepository<IEnumerable<string>, AccountMountTypeSnapshotEntity>
{
    public AccountMountTypeRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountMountTypeMapper.ToEntity, AccountMountTypeMapper.ToModel)
    {
    }
}
