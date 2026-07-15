using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Repositories.V2.Pvp;

public class PvpRankRepository : StaticRepository<PvpRank, PvpRankEntity, int>
{
    public PvpRankRepository(Gw2ApiPersistenceDatabase database)
        : base(database, PvpRankMapper.ToEntity, PvpRankMapper.ToModel)
    {
    }
}
