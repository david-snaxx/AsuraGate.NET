using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2;

public sealed class CurrencyRequest :
    IGetsSingle<Currency, int>,
    IGetsBulk<Currency, int>,
    IGetsAll<Currency>,
    IGetsIds<int>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.Currency;
    public bool IsAuthenticated { get; } = false;
    public bool IsLocalized { get; } = true;
}
