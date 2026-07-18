using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterRecipeRepository(Gw2ApiDynamicDatabase database)
    : KeyedSnapshotRepository<IEnumerable<int>, CharacterRecipeSnapshotEntity>(
        database, CharacterRecipeMapper.ToEntity, CharacterRecipeMapper.ToModel);
