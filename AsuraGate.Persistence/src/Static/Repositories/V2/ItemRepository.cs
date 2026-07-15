using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class ItemRepository : StaticRepository<Item, ItemEntity, int>
{
    public ItemRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ItemMapper.ToEntity, ItemMapper.ToModel)
    {
    }
}
