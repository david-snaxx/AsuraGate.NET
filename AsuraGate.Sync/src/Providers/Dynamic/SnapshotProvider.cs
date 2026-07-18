using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Polls an unkeyed GW2 API endpoint and records the result as a new snapshot. Unlike
/// <see cref="Provider{TModel,TId,TRepository,TRequest}"/>'s cache-aside behavior, every call
/// hits the API and appends a row - there's no such thing as a cache hit here, since the entire
/// point is capturing how the value changes over time. Reads are exposed via <see cref="Repository"/>
/// directly rather than re-declared one-for-one, since there's no cache logic to add on top of them.
/// </summary>
public class SnapshotProvider<TModel, TRepository, TRequest>
    where TRepository : ISnapshotRepository<TModel>
    where TRequest : IGetsSingleNoId<TModel>
{
    private static readonly string ResourceName = typeof(TModel).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly ILogger _logger;

    public SnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the current state from the API and records it as a new snapshot; returns the fetched value, or null if the fetch failed.</summary>
    public async Task<TModel?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<TModel, NoId> apiRequest = _request.GetObject<TModel, NoId>();
        TModel? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning("{Resource}: poll fetch returned null", ResourceName);
            return default;
        }

        await Repository.InsertAsync(fetched, timestamp);
        _logger.LogInformation("{Resource}: recorded new snapshot", ResourceName);
        return fetched;
    }
}
