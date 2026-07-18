using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountEmoteRepository : SnapshotRepository<IEnumerable<string>, AccountEmoteSnapshotEntity>
{
    public AccountEmoteRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountEmoteMapper.ToEntity, AccountEmoteMapper.ToModel)
    {
    }
}
