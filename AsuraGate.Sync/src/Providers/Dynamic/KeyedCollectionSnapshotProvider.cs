using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Keyed counterpart to <see cref="CollectionSnapshotProvider{TElement,TId,TRepository,TRequest}"/> -
/// for endpoints like a character's build tabs, where the request is already scoped to one entity at
/// construction time (the entity's key baked into the URL) but the response is still a full
/// collection fetched via <c>GetAll()</c> rather than a single object.
/// </summary>
public class KeyedCollectionSnapshotProvider<TElement, TId, TRepository, TRequest>
    where TRepository : IKeyedSnapshotRepository<IEnumerable<TElement>>
    where TRequest : IGetsAll<TElement, TId>
{
    private static readonly string ResourceName = typeof(TElement).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly string _key;
    private readonly ILogger _logger;

    public KeyedCollectionSnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _key = key;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the full collection from the API and records it as a new snapshot under this provider's key; returns the fetched collection, or null if the fetch failed.</summary>
    public async Task<IEnumerable<TElement>?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<IEnumerable<TElement>, TId> apiRequest = _request.GetAll();
        IEnumerable<TElement>? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning("{Resource}: poll fetch for key {Key} returned null", ResourceName, _key);
            return default;
        }

        await Repository.InsertAsync(_key, fetched, timestamp);
        _logger.LogInformation("{Resource}: recorded new snapshot for key {Key}", ResourceName, _key);
        return fetched;
    }
}
