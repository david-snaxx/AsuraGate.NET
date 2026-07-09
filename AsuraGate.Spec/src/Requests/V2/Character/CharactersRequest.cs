using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Character;

public sealed class CharactersRequest :
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Characters;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
