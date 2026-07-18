using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterQuestRepository : KeyedSnapshotRepository<IEnumerable<int>, CharacterQuestSnapshotEntity>
{
    public CharacterQuestRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterQuestMapper.ToEntity, CharacterQuestMapper.ToModel)
    {
    }
}
