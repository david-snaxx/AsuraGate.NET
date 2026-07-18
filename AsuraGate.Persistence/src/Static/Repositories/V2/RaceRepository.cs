using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class RaceRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Race, RaceEntity, string>(
        database, RaceMapper.ToEntity, RaceMapper.ToModel);
