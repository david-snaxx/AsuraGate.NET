using AsuraGate.Persistence.Entities.V2.Homestead;
using AsuraGate.Persistence.Mappers.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Repositories.V2.Homestead;

public class HomesteadDecorationRepository : StaticRepository<HomesteadDecoration, HomesteadDecorationEntity, int>
{
    public HomesteadDecorationRepository(Gw2ApiPersistenceDatabase database)
        : base(database, HomesteadDecorationMapper.ToEntity, HomesteadDecorationMapper.ToModel)
    {
    }
}
