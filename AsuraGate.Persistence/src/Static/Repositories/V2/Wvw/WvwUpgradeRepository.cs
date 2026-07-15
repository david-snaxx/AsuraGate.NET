using AsuraGate.Persistence.Entities.V2.Wvw;
using AsuraGate.Persistence.Mappers.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Repositories.V2.Wvw;

public class WvwUpgradeRepository : StaticRepository<WvwUpgrade, WvwUpgradeEntity, int>
{
    public WvwUpgradeRepository(Gw2ApiPersistenceDatabase database)
        : base(database, WvwUpgradeMapper.ToEntity, WvwUpgradeMapper.ToModel)
    {
    }
}
