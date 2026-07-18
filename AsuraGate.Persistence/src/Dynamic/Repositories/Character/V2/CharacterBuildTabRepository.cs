using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterBuildTabRepository : KeyedSnapshotRepository<IEnumerable<CharacterBuildTab>, CharacterBuildTabSnapshotEntity>
{
    public CharacterBuildTabRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterBuildTabMapper.ToEntity, CharacterBuildTabMapper.ToModel)
    {
    }
}
