using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class SkinRepository : StaticRepository<Skin, SkinEntity, int>
{
    public SkinRepository(Gw2ApiPersistenceDatabase database)
        : base(database, SkinMapper.ToEntity, SkinMapper.ToModel)
    {
    }
}
