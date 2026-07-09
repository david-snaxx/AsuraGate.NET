using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountHomesteadGlyphRequest :
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountHomesteadGlyph;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
