using AsuraGate.Persistence.Static.Entities.V2.Homestead;
using AsuraGate.Spec.Models.V2.Homestead;

namespace AsuraGate.Persistence.Static.Repositories.V2.Homestead;

public class HomesteadDecorationRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<HomesteadDecoration, HomesteadDecorationEntity, int>(database, model => model.Id);
