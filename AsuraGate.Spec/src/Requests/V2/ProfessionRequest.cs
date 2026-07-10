using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class ProfessionRequest :
    IGetsSingle<Profession, string>,
    IGetsBulk<Profession, string>,
    IGetsAll<Profession>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Profession;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
