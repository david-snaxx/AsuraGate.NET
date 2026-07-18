using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;
using AsuraGate.Spec.Models.V2.Account;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountMasteryPointsRepository : SnapshotRepository<AccountMasteryPoints, AccountMasteryPointsSnapshotEntity>
{
    public AccountMasteryPointsRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountMasteryPointsMapper.ToEntity, AccountMasteryPointsMapper.ToModel)
    {
    }
}
