using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class ProfessionRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Profession, ProfessionEntity, string>(database, model => model.Id);
