using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Polls a GW2 API endpoint that returns its full result as one collection (via <c>GetAll()</c>)
/// and records the whole collection as a single snapshot. Fits endpoints like
/// <c>/v2/account/bank</c> that hand back every item in one call rather than by id.
/// </summary>
public class CollectionSnapshotProvider<TElement, TId, TRepository, TRequest>
    where TRepository : ISnapshotRepository<IEnumerable<TElement>>
    where TRequest : IGetsAll<TElement, TId>
{
    private static readonly string ResourceName = typeof(TElement).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly ILogger _logger;

    public CollectionSnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the full collection from the API and records it as a new snapshot; returns the fetched collection, or null if the fetch failed.</summary>
    public async Task<IEnumerable<TElement>?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<IEnumerable<TElement>, TId> apiRequest = _request.GetAll();
        IEnumerable<TElement>? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
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
