
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class ContinentFloorRepository : StaticRepository<ContinentFloor, ContinentFloorEntity, int>
{
    public ContinentFloorRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ContinentFloorMapper.ToEntity, ContinentFloorMapper.ToModel)
    {
    }
}
