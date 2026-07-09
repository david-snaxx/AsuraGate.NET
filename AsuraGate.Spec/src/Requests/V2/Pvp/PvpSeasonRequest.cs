using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Pvp;

public sealed class PvpSeasonRequest :
    IGetsSingle<PvpSeason, string>,
    IGetsBulk<PvpSeason, string>,
    IGetsAll<PvpSeason>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.PvpSeason;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}