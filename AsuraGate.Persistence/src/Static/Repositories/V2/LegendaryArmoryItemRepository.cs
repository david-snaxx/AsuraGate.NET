using AsuraGate.Persistence.Static.Entities.V2;
using AsuraGate.Persistence.Static.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Static.Repositories.V2;

public class LegendaryArmoryItemRepository : StaticRepository<LegendaryArmoryItem, LegendaryArmoryItemEntity, int>
{
    public LegendaryArmoryItemRepository(Gw2ApiPersistenceDatabase database)
        : base(database, LegendaryArmoryItemMapper.ToEntity, LegendaryArmoryItemMapper.ToModel)
    {
    }
}
