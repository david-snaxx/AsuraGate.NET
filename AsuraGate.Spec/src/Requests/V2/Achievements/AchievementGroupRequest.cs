using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Requests.Components;

public class AchievementGroupRequest :
    IGetsSingle<AchievementGroup, string>,
    IGetsBulk<AchievementGroup, string>,
    IGetsAll<AchievementGroup>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AchievementGroup;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
