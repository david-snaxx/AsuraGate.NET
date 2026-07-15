using AsuraGate.Persistence.Entities.V2;
using AsuraGate.Persistence.Mappers.V2;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Persistence.Repositories.V2;

public class StoryJournalEntryRepository : StaticRepository<StoryJournalEntry, StoryJournalEntryEntity, int>
{
    public StoryJournalEntryRepository(Gw2ApiPersistenceDatabase database)
        : base(database, StoryJournalEntryMapper.ToEntity, StoryJournalEntryMapper.ToModel)
    {
    }
}
