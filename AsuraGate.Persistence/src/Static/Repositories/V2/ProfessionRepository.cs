using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class ProfessionRepository : StaticRepository<Profession, ProfessionEntity, string>
{
    public ProfessionRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ProfessionMapper.ToEntity, ProfessionMapper.ToModel)
    {
    }
}
