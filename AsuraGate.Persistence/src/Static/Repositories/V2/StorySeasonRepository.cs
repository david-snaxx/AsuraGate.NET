using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class StorySeasonRepository : StaticRepository<StorySeason, StorySeasonEntity, string>
{
    public StorySeasonRepository(Gw2ApiPersistenceDatabase database)
        : base(database, StorySeasonMapper.ToEntity, StorySeasonMapper.ToModel)
    {
    }
}
