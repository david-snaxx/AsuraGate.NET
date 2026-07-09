using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountMasteryPointsRequest :
    IGetsSingleNoId<AccountMasteryPoints>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountMasteryPoint;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
