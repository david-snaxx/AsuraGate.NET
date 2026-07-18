using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountJadeBotRepository : SnapshotRepository<IEnumerable<int>, AccountJadeBotSnapshotEntity>
{
    public AccountJadeBotRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountJadeBotMapper.ToEntity, AccountJadeBotMapper.ToModel)
    {
    }
}
