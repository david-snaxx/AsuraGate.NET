using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Homestead;

public class HomesteadGlyphRequest :
    IGetsSingle<HomesteadGlyph, string>,
    IGetsBulk<HomesteadGlyph, string>,
    IGetsAll<HomesteadGlyph>,
    IGetsIds<string>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.HomesteadGlyph;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = false;
}
