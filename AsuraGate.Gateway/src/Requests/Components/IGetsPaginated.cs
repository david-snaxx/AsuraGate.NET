namespace AsuraGate.Gateway.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for a paginated set of resources from the given endpoint.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type returned by this endpoint.</typeparam>
public interface IPaginated<TModel> : IGw2ApiRequest<IEnumerable<TModel>>;
