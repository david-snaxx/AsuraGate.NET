using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Keyed counterpart to <see cref="IdListSnapshotProvider{TId,TRepository,TRequest}"/> - for
/// endpoints like a character's hero points, where the request is already scoped to one entity at
/// construction time but the response is still a raw id list fetched via <c>GetAllIds()</c>.
/// </summary>
public class KeyedIdListSnapshotProvider<TId, TRepository, TRequest>
    where TRepository : IKeyedSnapshotRepository<IEnumerable<TId>>
    where TRequest : IGetsIds<TId>
{
    private static readonly string ResourceName = typeof(TRequest).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly string _key;
    private readonly ILogger _logger;

    public KeyedIdListSnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _key = key;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the current id list from the API and records it as a new snapshot under this provider's key; returns the fetched ids, or null if the fetch failed.</summary>
    public async Task<IEnumerable<TId>?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<IEnumerable<TId>, TId> apiRequest = _request.GetAllIds();
        IEnumerable<TId>? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
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
