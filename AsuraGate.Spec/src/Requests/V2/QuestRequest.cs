using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public class QuestRequest :
    IGetsSingle<StoryJournalEntry, int>,
    IGetsBulk<StoryJournalEntry, int>,
    IGetsAll<StoryJournalEntry>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Quest;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
