using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class MasteryRepository : StaticRepository<Mastery, MasteryEntity, int>
{
    public MasteryRepository(Gw2ApiPersistenceDatabase database)
        : base(database, MasteryMapper.ToEntity, MasteryMapper.ToModel)
    {
    }
}
