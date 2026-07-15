using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class OutfitRepository : StaticRepository<Outfit, OutfitEntity, int>
{
    public OutfitRepository(Gw2ApiPersistenceDatabase database)
        : base(database, OutfitMapper.ToEntity, OutfitMapper.ToModel)
    {
    }
}
