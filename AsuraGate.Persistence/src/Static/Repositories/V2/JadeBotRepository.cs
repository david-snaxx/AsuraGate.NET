using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class JadeBotRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<JadeBot, JadeBotEntity, int>(database, model => model.Id);
