using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Mappers.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Repositories.V2.Wvw;

public class WvwObjectiveRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<WvwObjective, WvwObjectiveEntity, string>(
        database, WvwObjectiveMapper.ToEntity, WvwObjectiveMapper.ToModel);
