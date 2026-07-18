using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMiniRepository : SnapshotRepository<IEnumerable<int>, AccountMiniSnapshotEntity>
{
    public AccountMiniRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountMiniMapper.ToEntity, AccountMiniMapper.ToModel)
    {
    }
}
