using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class HomeCatRepository : StaticRepository<HomeCat, HomeCatEntity, int>
{
    public HomeCatRepository(Gw2ApiPersistenceDatabase database)
        : base(database, HomeCatMapper.ToEntity, HomeCatMapper.ToModel)
    {
    }
}
