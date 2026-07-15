using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class PetRepository : StaticRepository<Pet, PetEntity, int>
{
    public PetRepository(Gw2ApiPersistenceDatabase database)
        : base(database, PetMapper.ToEntity, PetMapper.ToModel)
    {
    }
}
