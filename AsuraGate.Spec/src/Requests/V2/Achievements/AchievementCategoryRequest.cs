using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Achievements;

public sealed class AchievementCategoryRequest :
    IGetsSingle<AchievementCategory, int>,
    IGetsBulk<AchievementCategory, int>,
    IGetsAll<AchievementCategory>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AchievementCategory;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
