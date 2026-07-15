using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class DungeonRepository : StaticRepository<Dungeon, DungeonEntity, string>
{
    public DungeonRepository(Gw2ApiPersistenceDatabase database)
        : base(database, DungeonMapper.ToEntity, DungeonMapper.ToModel)
    {
    }
}
