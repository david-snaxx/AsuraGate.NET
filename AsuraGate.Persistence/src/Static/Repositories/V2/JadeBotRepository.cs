using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class JadeBotRepository : StaticRepository<JadeBot, JadeBotEntity, int>
{
    public JadeBotRepository(Gw2ApiPersistenceDatabase database)
        : base(database, JadeBotMapper.ToEntity, JadeBotMapper.ToModel)
    {
    }
}
