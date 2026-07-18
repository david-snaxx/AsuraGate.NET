using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class DyeRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Dye, DyeEntity, int>(database, model => model.Id);
