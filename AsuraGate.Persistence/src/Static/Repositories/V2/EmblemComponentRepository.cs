using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class EmblemComponentRepository : StaticRepository<EmblemComponent, EmblemComponentEntity, int>
{
    public EmblemComponentRepository(Gw2ApiPersistenceDatabase database)
        : base(database, EmblemComponentMapper.ToEntity, EmblemComponentMapper.ToModel)
    {
    }
}
