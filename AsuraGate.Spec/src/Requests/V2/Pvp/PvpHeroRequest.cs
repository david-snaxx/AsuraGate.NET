using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpHeroRequest :
    IGetsSingle<PvpHero, string>,
    IGetsBulk<PvpHero, string>,
    IGetsAll<PvpHero>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpHero;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
