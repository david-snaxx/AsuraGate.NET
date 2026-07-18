using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterSabRepository : KeyedSnapshotRepository<CharacterSab, CharacterSabSnapshotEntity>
{
    public CharacterSabRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterSabMapper.ToEntity, CharacterSabMapper.ToModel)
    {
    }
}
