using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers.Dynamic;

/// <summary>
/// Polls a GW2 API endpoint fetched by <typeparamref name="TId"/> and records the result as a new
/// keyed snapshot. The fetch id and the storage key aren't always the same thing - e.g. the WvW
/// match detail endpoints accept a world id but the match itself is keyed by match id - so the key
/// actually stored under is derived from the fetched model via <paramref name="keySelector"/>
/// rather than assumed to equal the fetch id. Mirrors <see cref="SnapshotProvider{TModel,TRepository,TRequest}"/>
/// otherwise, including exposing reads via <see cref="Repository"/> directly.
/// </summary>
public class KeyedSnapshotProvider<TModel, TId, TRepository, TRequest>
    where TRepository : IKeyedSnapshotRepository<TModel>
    where TRequest : IGetsSingle<TModel, TId>
{
    private static readonly string ResourceName = typeof(TModel).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly Func<TModel, string> _keySelector;
    private readonly ILogger _logger;

    public KeyedSnapshotProvider(
        TRepository repository,
        TRequest request,
        Gw2ApiGateway gateway,
        Func<TModel, string> keySelector,
        ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _keySelector = keySelector;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the current state of <paramref name="id"/> from the API and records it as a new snapshot keyed by the fetched model's own key; returns the fetched value, or null if the fetch failed.</summary>
    public async Task<TModel?> PollAsync(TId id, DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<TModel, TId> apiRequest = _request.GetById(id);
        TModel? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning("{Resource}: poll fetch for id {Id} returned null", ResourceName, id);
            return default;
        }

        string key = _keySelector(fetched);
        await Repository.InsertAsync(key, fetched, timestamp);
        _logger.LogInformation("{Resource}: recorded new snapshot for key {Key}", ResourceName, key);
        return fetched;
    }
}

/// <summary>
/// Polls a GW2 API endpoint whose request is already scoped to one entity at construction time -
/// e.g. a character-specific request built via <c>Gw2ApiNavigator...Characters.CharacterCore(name)</c>,
/// which bakes the character name into the URL rather than accepting it as a fetch id - and records
/// the result under an externally supplied key rather than one derived from the fetched model.
/// Otherwise identical to <see cref="SnapshotProvider{TModel,TRepository,TRequest}"/> plus keyed storage.
/// </summary>
public class KeyedSnapshotProvider<TModel, TRepository, TRequest>
    where TRepository : IKeyedSnapshotRepository<TModel>
    where TRequest : IGetsSingleNoId<TModel>
{
    private static readonly string ResourceName = typeof(TModel).Name;

    public TRepository Repository { get; }

    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;
    private readonly string _key;
    private readonly ILogger _logger;

    public KeyedSnapshotProvider(TRepository repository, TRequest request, Gw2ApiGateway gateway, string key, ILogger? logger = null)
    {
        Repository = repository;
        _request = request;
        _gateway = gateway;
        _key = key;
        _logger = logger ?? NullLogger.Instance;
    }

    /// <summary>Fetches the current state from the API and records it as a new snapshot under this provider's key; returns the fetched value, or null if the fetch failed.</summary>
    public async Task<TModel?> PollAsync(DateTime? timestamp = null, CancellationToken cancellationToken = default)
    {
        IExecutableGw2ApiRequest<TModel, NoId> apiRequest = _request.GetObject<TModel, NoId>();
        TModel? fetched = await _gateway.FetchAsync(apiRequest, cancellationToken);
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
