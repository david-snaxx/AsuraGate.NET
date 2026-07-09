namespace AsuraGate.Gateway.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for all valid IDs for the given endpoint.
/// </summary>
/// <typeparam name="TId">The ID type for this endpoint; typically a string or integer.</typeparam>
public interface IGetsIds<TId> : IGw2ApiRequest<IEnumerable<TId>>;
