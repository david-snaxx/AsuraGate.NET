namespace AsuraGate.Gateway.Requests.Components;

/// <summary>
/// Represents a request capability signaling that the request can fetch for a single resource from the given endpoint
/// without requiring an ID.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type returned by this endpoint.</typeparam>
public interface IGetsSingleNoId<TModel> : IGw2ApiRequest<TModel>;
