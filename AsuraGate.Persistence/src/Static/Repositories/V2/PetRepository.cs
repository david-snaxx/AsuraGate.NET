using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class PetRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Pet, PetEntity, int>(
        database, PetMapper.ToEntity, PetMapper.ToModel);
