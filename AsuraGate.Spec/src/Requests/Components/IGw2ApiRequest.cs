namespace AsuraGate.Spec.Requests.Components;

public interface IGw2ApiRequest<TModel>
{
    string EndpointUrl { get; }
    bool IsAuthenticated { get; }
    bool IsLocalized { get; }
}
