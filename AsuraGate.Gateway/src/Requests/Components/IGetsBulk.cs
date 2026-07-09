namespace AsuraGate.Gateway.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for multiple resources from the given endpoint.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type returned by this endpoint.</typeparam>
/// <typeparam name="TId">The ID type for this endpoint; typically a string or integer.</typeparam>
public interface IGetsBulk<TModel, TId> : IGw2ApiRequest<IEnumerable<TModel>>;
