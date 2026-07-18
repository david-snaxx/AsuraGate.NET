using AsuraGate.Persistence.Dynamic.Entities.Wvw.V2;
using AsuraGate.Spec.Models.V2.Wvw;

namespace AsuraGate.Persistence.Dynamic.Repositories.Wvw.V2;

public class WvwMatchRepository(Gw2ApiDynamicDatabase database)
    : KeyedSnapshotRepository<WvwMatch, WvwMatchSnapshotEntity>(database);
