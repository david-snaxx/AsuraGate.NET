using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class ItemStatRepository(Gw2ApiPersistenceDatabase database)
    : StaticRepository<ItemStat, ItemStatEntity, int>(database, model => model.Id);
