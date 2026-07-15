using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Repositories.V2.Pvp;

public class PvpAmuletRepository : StaticRepository<PvpAmulet, PvpAmuletEntity, int>
{
    public PvpAmuletRepository(Gw2ApiPersistenceDatabase database)
        : base(database, PvpAmuletMapper.ToEntity, PvpAmuletMapper.ToModel)
    {
    }
}
