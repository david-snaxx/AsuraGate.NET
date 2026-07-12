using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class StorySeasonRequest :
    IGetsSingle<StorySeason, string>,
    IGetsBulk<StorySeason, string>,
    IGetsAll<StorySeason, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.StorySeason;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
