using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountPvpHeroRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<int>, AccountPvpHeroSnapshotEntity>(
        database, AccountPvpHeroMapper.ToEntity, AccountPvpHeroMapper.ToModel);
