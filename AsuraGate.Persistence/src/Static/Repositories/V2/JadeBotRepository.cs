using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class JadeBotRepository : StaticRepository<JadeBot, JadeBotEntity, int>
{
    public JadeBotRepository(Gw2ApiPersistenceDatabase database)
        : base(database, JadeBotMapper.ToEntity, JadeBotMapper.ToModel)
    {
    }
}
