using AsuraGate.Persistence.Static.Entities.V2.Pvp;
using AsuraGate.Persistence.Static.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Static.Repositories.V2.Pvp;

public class PvpRankRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<PvpRank, PvpRankEntity, int>(
        database, PvpRankMapper.ToEntity, PvpRankMapper.ToModel);
