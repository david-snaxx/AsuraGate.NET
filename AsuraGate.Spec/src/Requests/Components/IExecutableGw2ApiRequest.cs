namespace AsuraGate.Spec.Requests.Components;

public interface IExecutableGw2ApiRequest<TModel, TId>
{
    IGw2ApiRequest<TModel> BaseRequest { get; }
    string IdParamKey { get; }
    IEnumerable<TId> IdValues { get; }
    IEnumerable<KeyValuePair<string, string>> ExtraQueryParams { get; }
    public bool IsGetAllRequest { get; }
}

/// <summary>
/// Represents a request directed to the GW2 API with additional query parameters.
/// </summary>
/// <typeparam name="TModel">The GW2 API model type and or ID type returned by this endpoint.</typeparam>
/// <typeparam name="TId">The ID type for this endpoint; typically a string or integer.</typeparam>
internal class ExecutableGw2ApiRequest<TModel, TId> : IExecutableGw2ApiRequest<TModel, TId>
{
    public required IGw2ApiRequest<TModel> BaseRequest { get; set; }
    public string IdParamKey { get; set; } = string.Empty;
    public IEnumerable<TId> IdValues { get; set; } = [];
    public IEnumerable<KeyValuePair<string, string>> ExtraQueryParams { get; set; } = [];
    public bool IsGetAllRequest { get; set; } = false;
}
