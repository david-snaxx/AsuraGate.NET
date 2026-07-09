using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class RecipeRequest :
    IGetsSingle<Recipe, int>,
    IGetsBulk<Recipe, int>,
    IGetsAll<Recipe>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Recipe;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
