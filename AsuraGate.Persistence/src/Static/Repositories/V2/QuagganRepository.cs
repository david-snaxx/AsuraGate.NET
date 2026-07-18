using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class QuagganRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Quaggan, QuagganEntity, string>(database, model => model.Id);
