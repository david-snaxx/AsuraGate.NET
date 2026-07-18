using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class EmoteRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Emote, EmoteEntity, string>(database, model => model.Id);
