namespace AsuraGate.Spec.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for all resources from the given endpoint.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type returned by this endpoint.</typeparam>
public interface IGetsAll<TModel> : IGw2ApiRequest<IEnumerable<TModel>>;
