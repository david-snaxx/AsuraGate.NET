using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class RaidRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Raid, RaidEntity, string>(
        database, RaidMapper.ToEntity, RaidMapper.ToModel);
