using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterQuestRepository(Gw2ApiDynamicDatabase database)
    : KeyedSnapshotRepository<IEnumerable<int>, CharacterQuestSnapshotEntity>(
        database, CharacterQuestMapper.ToEntity, CharacterQuestMapper.ToModel);
