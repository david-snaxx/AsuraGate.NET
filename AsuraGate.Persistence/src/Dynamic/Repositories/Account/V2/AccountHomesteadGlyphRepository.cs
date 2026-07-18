using AsuraGate.Persistence.Dynamic.Entities.Account.V2;
using AsuraGate.Persistence.Dynamic.Mappers.Account.V2;

namespace AsuraGate.Persistence.Dynamic.Repositories.Account.V2;

public class AccountHomesteadGlyphRepository : SnapshotRepository<IEnumerable<string>, AccountHomesteadGlyphSnapshotEntity>
{
    public AccountHomesteadGlyphRepository(Gw2ApiDynamicDatabase database)
        : base(database, AccountHomesteadGlyphMapper.ToEntity, AccountHomesteadGlyphMapper.ToModel)
    {
    }
}
