using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Repositories.V2.Pvp;

public class PvpHeroRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<PvpHero, PvpHeroEntity, string>(database, model => model.Id);
