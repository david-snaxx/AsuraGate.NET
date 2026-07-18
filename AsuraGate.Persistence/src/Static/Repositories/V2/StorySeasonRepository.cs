using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class StorySeasonRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<StorySeason, StorySeasonEntity, string>(database, model => model.Id);
