using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountOutfitRepository : SnapshotRepository<IEnumerable<int>, AccountOutfitSnapshotEntity>
{
    public AccountOutfitRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountOutfitMapper.ToEntity, AccountOutfitMapper.ToModel)
    {
    }
}
