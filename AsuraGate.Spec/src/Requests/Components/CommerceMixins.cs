using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Commerce;
using AsuraGate.Spec.Requests.V2.Commerce;

namespace AsuraGate.Spec.Requests.Components;

public static class CommerceMixins
{
    public static IExecutableGw2ApiRequest<CommerceExchange, string> Calculate<TModel>(
        this CommerceExchangeCoinsRequest request,
        int gemQuantity)
    {
        if (gemQuantity <= 0) throw new ArgumentException("Must have a positive gem quantity");
        return new ExecutableGw2ApiRequest<CommerceExchange, string>()
        {
            BaseRequest = request,
            ExtraQueryParams = [new KeyValuePair<string, string>("quantity", gemQuantity.ToString())]
        };
    }
    
    public static IExecutableGw2ApiRequest<CommerceExchange, string> Calculate<TModel>(
        this CommerceExchangeGemsRequest request,
        int coinQuantity)
    {
        if (coinQuantity <= 0) throw new ArgumentException("Must have a positive coin quantity");
        return new ExecutableGw2ApiRequest<CommerceExchange, string>()
        {
            BaseRequest = request,
            ExtraQueryParams = [new KeyValuePair<string, string>("quantity", coinQuantity.ToString())]
        };
    }
}