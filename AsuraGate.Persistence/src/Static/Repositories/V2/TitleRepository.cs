using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class TitleRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<Title, TitleEntity, int>(database, model => model.Id);
