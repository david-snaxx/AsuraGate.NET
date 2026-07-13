using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.StaticCache.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class StoryJournalEntryProvider : Provider<StoryJournalEntry, int, StoryJournalEntryRepository, QuestRequest>
{
    public StoryJournalEntryProvider(StoryJournalEntryRepository repository, QuestRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
