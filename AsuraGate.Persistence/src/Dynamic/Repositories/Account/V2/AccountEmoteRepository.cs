using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountEmoteRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<string>, AccountEmoteSnapshotEntity>(
        database, AccountEmoteMapper.ToEntity, AccountEmoteMapper.ToModel);
