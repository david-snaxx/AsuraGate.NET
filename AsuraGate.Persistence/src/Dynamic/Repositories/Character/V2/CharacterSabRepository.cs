using AsuraGate.Persistence.Dynamic.Entities.Character.V2;
using AsuraGate.Spec.Models.V2.Characters;

namespace AsuraGate.Persistence.Dynamic.Repositories.Character.V2;

public class CharacterSabRepository(Gw2ApiDynamicDatabase database)
    : KeyedSnapshotRepository<CharacterSab, CharacterSabSnapshotEntity>(database);
