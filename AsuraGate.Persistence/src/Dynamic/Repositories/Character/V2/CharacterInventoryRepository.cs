using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterInventoryRepository : KeyedSnapshotRepository<CharacterInventory, CharacterInventorySnapshotEntity>
{
    public CharacterInventoryRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterInventoryMapper.ToEntity, CharacterInventoryMapper.ToModel)
    {
    }
}
