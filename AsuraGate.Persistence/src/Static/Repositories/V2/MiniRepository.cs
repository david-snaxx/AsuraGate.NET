using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class MiniRepository : StaticRepository<Mini, MiniEntity, int>
{
    public MiniRepository(Gw2ApiPersistenceDatabase database)
        : base(database, MiniMapper.ToEntity, MiniMapper.ToModel)
    {
    }
}
