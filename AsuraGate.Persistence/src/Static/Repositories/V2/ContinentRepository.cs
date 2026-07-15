using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class ContinentRepository : StaticRepository<Continent, ContinentEntity, int>
{
    public ContinentRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ContinentMapper.ToEntity, ContinentMapper.ToModel)
    {
    }
}
