using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Achievements;

public sealed class AchievementGroupRequest :
    IGetsSingle<AchievementGroup, string>,
    IGetsBulk<AchievementGroup, string>,
    IGetsAll<AchievementGroup, string>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AchievementGroup;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
