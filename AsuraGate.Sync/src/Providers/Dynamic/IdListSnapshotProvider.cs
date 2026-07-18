using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Polls a GW2 API endpoint whose entire response is a raw id list (via <c>GetAllIds()</c>) and
/// records that list as a single snapshot. Fits endpoints like <c>/v2/account/dyes</c> that
/// return unlocked ids directly with no wrapping object.
/// </summary>
public class IdListSnapshotProvider<TId, TRepository, TRequest>
    where TRepository : ISnapshotRepository<IEnumerable<TId>>
    where TRequest : IGetsIds<TId>
{
    private static readonly string ResourceName = typeof(TRequest).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly ILogger _logger;

    public IdListSnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the current id list from the API and records it as a new snapshot; returns the fetched ids, or null if the fetch failed.</summary>
    public async Task<IEnumerable<TId>?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<IEnumerable<TId>, TId> apiRequest = _request.GetAllIds();
        IEnumerable<TId>? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
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
