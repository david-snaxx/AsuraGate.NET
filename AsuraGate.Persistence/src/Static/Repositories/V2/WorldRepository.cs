using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class WorldRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<World, WorldEntity, int>(database, model => model.Id);
