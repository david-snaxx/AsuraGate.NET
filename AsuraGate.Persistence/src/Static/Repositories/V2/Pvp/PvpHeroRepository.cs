using AsuraGate.Persistence.Entities.V2.Pvp;
using AsuraGate.Persistence.Mappers.V2.Pvp;
using AsuraGate.Spec.Models.V2.Pvp;

namespace AsuraGate.Persistence.Repositories.V2.Pvp;

public class PvpHeroRepository : StaticRepository<PvpHero, PvpHeroEntity, string>
{
    public PvpHeroRepository(Gw2ApiPersistenceDatabase database)
        : base(database, PvpHeroMapper.ToEntity, PvpHeroMapper.ToModel)
    {
    }
}
