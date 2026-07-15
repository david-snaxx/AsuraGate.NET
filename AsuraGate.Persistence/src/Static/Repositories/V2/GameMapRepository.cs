using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class GameMapRepository : StaticRepository<GameMap, GameMapEntity, int>
{
    public GameMapRepository(Gw2ApiPersistenceDatabase database)
        : base(database, GameMapMapper.ToEntity, GameMapMapper.ToModel)
    {
    }
}
