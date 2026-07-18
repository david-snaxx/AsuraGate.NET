using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomesteadDecorationRepository(Gw2ApiDynamicDatabase database)
    : SnapshotRepository<IEnumerable<AccountHomesteadDecoration>, AccountHomesteadDecorationSnapshotEntity>(
        database, AccountHomesteadDecorationMapper.ToEntity, AccountHomesteadDecorationMapper.ToModel);
