using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Repositories.V2.Pvp;

public class PvpAmuletRepository : StaticRepository<PvpAmulet, PvpAmuletEntity, int>
{
    public PvpAmuletRepository(Gw2ApiPersistenceDatabase database)
        : base(database, PvpAmuletMapper.ToEntity, PvpAmuletMapper.ToModel)
    {
    }
}
