using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class NoveltyRepository : StaticRepository<Novelty, NoveltyEntity, int>
{
    public NoveltyRepository(Gw2ApiPersistenceDatabase database)
        : base(database, NoveltyMapper.ToEntity, NoveltyMapper.ToModel)
    {
    }
}
