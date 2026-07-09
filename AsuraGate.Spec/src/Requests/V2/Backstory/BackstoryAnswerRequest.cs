using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Backstory;

public sealed class BackstoryAnswerRequest :
    IGetsSingle<BackstoryAnswer, string>,
    IGetsBulk<BackstoryAnswer, string>,
    IGetsAll<BackstoryAnswer>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.BackstoryAnswer;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
