using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class SkinRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Skin, SkinEntity, int>(database, model => model.Id);
