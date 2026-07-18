using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterEquipmentRepository : KeyedSnapshotRepository<CharacterEquipment, CharacterEquipmentSnapshotEntity>
{
    public CharacterEquipmentRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterEquipmentMapper.ToEntity, CharacterEquipmentMapper.ToModel)
    {
    }
}
