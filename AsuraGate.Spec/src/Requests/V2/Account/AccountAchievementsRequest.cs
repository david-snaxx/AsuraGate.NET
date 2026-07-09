using AsuraGate.Spec.Requests.Components;
using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountAchievementsRequest :
    IGetsSingle<AccountAchievement, int>,
    IGetsBulk<AccountAchievement, int>,
    IGetsAll<AccountAchievement>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountAchievement;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
