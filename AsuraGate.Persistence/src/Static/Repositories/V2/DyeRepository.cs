using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class DyeRepository : StaticRepository<Dye, DyeEntity, int>
{
    public DyeRepository(Gw2ApiPersistenceDatabase database)
        : base(database, DyeMapper.ToEntity, DyeMapper.ToModel)
    {
    }
}
