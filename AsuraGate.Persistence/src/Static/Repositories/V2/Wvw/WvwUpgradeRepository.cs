using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Mappers.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Repositories.V2.Wvw;

public class WvwUpgradeRepository : StaticRepository<WvwUpgrade, WvwUpgradeEntity, int>
{
    public WvwUpgradeRepository(Gw2ApiPersistenceDatabase database)
        : base(database, WvwUpgradeMapper.ToEntity, WvwUpgradeMapper.ToModel)
    {
    }
}
