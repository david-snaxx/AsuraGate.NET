using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountGliderRepository : SnapshotRepository<IEnumerable<int>, AccountGliderSnapshotEntity>
{
    public AccountGliderRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountGliderMapper.ToEntity, AccountGliderMapper.ToModel)
    {
    }
}
