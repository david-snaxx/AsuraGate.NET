using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class TraitRepository : StaticRepository<Trait, TraitEntity, int>
{
    public TraitRepository(Gw2ApiPersistenceDatabase database)
        : base(database, TraitMapper.ToEntity, TraitMapper.ToModel)
    {
    }
}
