using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public class AccountRecipeRequest :
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountRecipe;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
