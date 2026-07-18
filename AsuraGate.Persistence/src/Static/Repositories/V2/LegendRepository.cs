using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class LegendRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Legend, LegendEntity, string>(database, model => model.Id);
