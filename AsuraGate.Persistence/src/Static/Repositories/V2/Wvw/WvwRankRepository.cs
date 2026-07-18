using AsuraGate.Persistence.Static.Entities.V2.Wvw;
using AsuraGate.Persistence.Static.Mappers.V2.Wvw;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Static.Repositories.V2.Wvw;

public class WvwRankRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<WvwRank, WvwRankEntity, int>(
        database, WvwRankMapper.ToEntity, WvwRankMapper.ToModel);
