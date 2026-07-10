using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Achievements;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Achievements;

public sealed class AchievementDailyTomorrowRequest :
    IGetsSingleNoId<AchievementDaily>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AchievementsDailyTomorrow;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
