using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class QuagganRepository : StaticRepository<Quaggan, QuagganEntity, string>
{
    public QuagganRepository(Gw2ApiPersistenceDatabase database)
        : base(database, QuagganMapper.ToEntity, QuagganMapper.ToModel)
    {
    }
}
