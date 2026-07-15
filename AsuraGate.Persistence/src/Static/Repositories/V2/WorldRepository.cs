using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class WorldRepository : StaticRepository<World, WorldEntity, int>
{
    public WorldRepository(Gw2ApiPersistenceDatabase database)
        : base(database, WorldMapper.ToEntity, WorldMapper.ToModel)
    {
    }
}
