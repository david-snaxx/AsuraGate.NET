using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Backstory;

public sealed class BackstoryQuestionRequest :
    IGetsSingle<BackstoryQuestion, int>,
    IGetsBulk<BackstoryQuestion, int>,
    IGetsAll<BackstoryQuestion>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.BackstoryQuestion;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
