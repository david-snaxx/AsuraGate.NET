using AsuraGate.Persistence.Dynamic.Entities.Character.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterHeroPointRepository(Gw2ApiDynamicDatabase database)
    : KeyedSnapshotRepository<IEnumerable<string>, CharacterHeroPointSnapshotEntity>(database, "[]");
