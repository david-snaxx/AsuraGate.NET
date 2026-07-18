using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Repositories.V2.Pvp;

public class PvpAmuletRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<PvpAmulet, PvpAmuletEntity, int>(
        database, PvpAmuletMapper.ToEntity, PvpAmuletMapper.ToModel);
