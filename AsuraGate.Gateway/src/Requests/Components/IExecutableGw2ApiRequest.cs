namespace AsuraGate.Gateway.Requests.Components;

public interface IExecutableGw2ApiRequest<TModel>
{
    IGw2ApiRequest<TModel> BaseRequest { get; }
    IEnumerable<KeyValuePair<string, string>> ExtraQueryParameters { get; }
}

/// <summary>
/// Represents a request directed to the GW2 API with additional query parameters.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type and or ID type returned by this endpoint.</typeparam>
internal class ExecutableGw2ApiRequest<TModel> : IExecutableGw2ApiRequest<TModel>
{
    public IGw2ApiRequest<TModel> BaseRequest { get; set; }
    public IEnumerable<KeyValuePair<string, string>> ExtraQueryParameters { get; set; }
}
