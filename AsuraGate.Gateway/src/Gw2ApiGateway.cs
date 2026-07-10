using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Gateway;

public class Gw2ApiGateway
{
    private string ApiKey { get; }
    private string Localization { get; }
    private string SchemaVersion { get; }
    private readonly Gw2ApiService _gw2ApiService = Gw2ApiService.Instance;

    public Gw2ApiGateway(string apiKey)
        : this(apiKey, Gw2ApiLocalization.English, Gw2ApiSchemaVersion.Latest)
    {
    }

    public Gw2ApiGateway(string apiKey, string localization, string schemaVersion)
    {
        ApiKey = apiKey;
        Localization = localization;
        SchemaVersion = schemaVersion;
    }

    public async Task<TModel?> FetchAsync<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        CancellationToken cancellationToken = default)
    {
        Gw2ApiRequestContext context = new(ApiKey, Localization, SchemaVersion);
        return await _gw2ApiService.GetAsync(request, context, cancellationToken);
    }
}