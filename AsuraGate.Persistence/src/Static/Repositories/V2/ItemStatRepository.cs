using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class ItemStatRepository : StaticRepository<ItemStat, ItemStatEntity, int>
{
    public ItemStatRepository(Gw2ApiPersistenceDatabase database)
        : base(database, ItemStatMapper.ToEntity, ItemStatMapper.ToModel)
    {
    }
}
