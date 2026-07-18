using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class EmblemForegroundRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<EmblemComponent, EmblemForegroundEntity, int>(database, model => model.Id);
