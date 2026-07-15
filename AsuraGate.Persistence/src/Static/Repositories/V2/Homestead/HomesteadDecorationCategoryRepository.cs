using AsuraGate.Persistence.Entities.V2.Homestead;
using AsuraGate.Persistence.Mappers.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Repositories.V2.Homestead;

public class HomesteadDecorationCategoryRepository : StaticRepository<HomesteadDecorationCategory, HomesteadDecorationCategoryEntity, int>
{
    public HomesteadDecorationCategoryRepository(Gw2ApiPersistenceDatabase database)
        : base(database, HomesteadDecorationCategoryMapper.ToEntity, HomesteadDecorationCategoryMapper.ToModel)
    {
    }
}
