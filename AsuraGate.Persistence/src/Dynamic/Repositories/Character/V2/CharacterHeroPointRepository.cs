using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterHeroPointRepository : KeyedSnapshotRepository<IEnumerable<string>, CharacterHeroPointSnapshotEntity>
{
    public CharacterHeroPointRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterHeroPointMapper.ToEntity, CharacterHeroPointMapper.ToModel)
    {
    }
}
