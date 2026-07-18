using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountPvpHeroRepository : SnapshotRepository<IEnumerable<int>, AccountPvpHeroSnapshotEntity>
{
    public AccountPvpHeroRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountPvpHeroMapper.ToEntity, AccountPvpHeroMapper.ToModel)
    {
    }
}
