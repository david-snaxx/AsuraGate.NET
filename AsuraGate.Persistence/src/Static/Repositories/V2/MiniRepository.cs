using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class MiniRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Mini, MiniEntity, int>(database, model => model.Id);
