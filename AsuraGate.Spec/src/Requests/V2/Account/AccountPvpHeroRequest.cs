using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountPvpHeroRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountPvpHero;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
