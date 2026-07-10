using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Gateway;

public class Gw2ApiGateway
{
    private string ApiKey { get; }
    private string Localization { get; }
    private string SchemaVersion { get; }
    private readonly ILogger _logger;
    private readonly Gw2ApiService _gw2ApiService = Gw2ApiService.Instance;

    public Gw2ApiGateway(
        string apiKey,
        string localization = Gw2ApiLocalization.English,
        string schemaVersion = Gw2ApiSchemaVersion.Latest,
        ILogger? logger = null)
    {
        ApiKey = apiKey;
        Localization = localization;
        SchemaVersion = schemaVersion;
        _logger = logger ?? NullLogger.Instance;
    }

    public async Task<TModel?> FetchAsync<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        CancellationToken cancellationToken = default)
    {
        Gw2ApiRequestContext context = new(ApiKey, Localization, SchemaVersion);
        return await _gw2ApiService.GetAsync(request, context, _logger, cancellationToken);
    }
}