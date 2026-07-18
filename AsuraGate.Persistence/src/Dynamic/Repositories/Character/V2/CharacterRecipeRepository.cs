using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterRecipeRepository : KeyedSnapshotRepository<IEnumerable<int>, CharacterRecipeSnapshotEntity>
{
    public CharacterRecipeRepository(Gw2ApiDynamicDatabase database)
        : base(database, CharacterRecipeMapper.ToEntity, CharacterRecipeMapper.ToModel)
    {
    }
}
