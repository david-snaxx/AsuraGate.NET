using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class SkiffRepository : StaticRepository<Skiff, SkiffEntity, int>
{
    public SkiffRepository(Gw2ApiPersistenceDatabase database)
        : base(database, SkiffMapper.ToEntity, SkiffMapper.ToModel)
    {
    }
}
