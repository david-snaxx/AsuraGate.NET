using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountRecipeRepository : SnapshotRepository<IEnumerable<int>, AccountRecipeSnapshotEntity>
{
    public AccountRecipeRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountRecipeMapper.ToEntity, AccountRecipeMapper.ToModel)
    {
    }
}
