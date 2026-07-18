using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Repositories.V2.Wvw;

public class WvwAbilityRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<WvwAbility, WvwAbilityEntity, int>(database, model => model.Id);
