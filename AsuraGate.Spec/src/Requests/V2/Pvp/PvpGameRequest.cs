using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Pvp;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpGameRequest :
    IGetsSingle<PvpGame, string>,
    IGetsBulk<PvpGame, string>,
    IGetsAll<PvpGame, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpGame;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
