namespace AsuraGate.Spec.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for a single resource from the given endpoint.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type returned by this endpoint.</typeparam>
/// <typeparam name="TId">The ID type for this endpoint; typically a string or integer.</typeparam>
public interface IGetsSingle<TModel, TId> : IGw2ApiRequest<TModel>;
