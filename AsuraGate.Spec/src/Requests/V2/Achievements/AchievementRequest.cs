using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Achievements;

public sealed class AchievementRequest :
    IGetsSingle<Achievement, int>,
    IGetsBulk<Achievement, int>,
    IGetsAll<Achievement>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Achievement;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
