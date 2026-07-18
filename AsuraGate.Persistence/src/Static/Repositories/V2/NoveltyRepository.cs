using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class NoveltyRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Novelty, NoveltyEntity, int>(database, model => model.Id);
