using AsuraGate.Gateway;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.Persistence.Static.Meta;
using AsuraGate.Persistence.Static.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AsuraGate.Sync.Providers;

public class Provider<TModel, TId, TRepository, TRequest>
    where TRepository : IStaticRepository<TModel, TId>
    where TRequest : IGetsSingle<TModel, TId>, IGetsBulk<TModel, TId>, IGetsAll<TModel, TId>, IGetsIds<TId>
{
    private static readonly string ResourceName = typeof(TModel).Name;

    protected TRepository Repository { get; }
    protected TRequest Request { get; }
    protected Gw2ApiGateway Gateway { get; }
    private readonly StaticMetaRepository _staticMetaRepository;
    private readonly ILogger _logger;

    public Provider(TRepository repository, TRequest request, Gw2ApiGateway gateway, StaticMetaRepository staticMetaRepository, ILogger? logger = null)
    {
        Repository = repository;
        Request = request;
        Gateway = gateway;
        _staticMetaRepository = staticMetaRepository;
        _logger = logger ?? NullLogger.Instance;
    }

    public async Task<TModel?> GetById(TId id, CancellationToken cancellationToken = default)
    {
        TModel? cached = await Repository.GetAsync(id);
        if (cached is not null)
        {
            _logger.LogDebug("{Resource}: cache hit for id {Id}", ResourceName, id);
            return cached;
        }

        _logger.LogInformation("{Resource}: cache miss for id {Id}; fetching from API", ResourceName, id);
        IExecutableGw2ApiRequest<TModel, TId> request = Request.GetById(id);
        TModel? fetched = await Gateway.FetchAsync(request, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning("{Resource}: fetch for id {Id} returned null", ResourceName, id);
            return default;
        }

        // fill cache with missing data
        await Repository.UpsertAsync(fetched);
        _logger.LogInformation("{Resource}: cached id {Id} after fetch", ResourceName, id);

        return fetched;
    }

    public async Task<IEnumerable<TModel>> GetBulk(IEnumerable<TId> ids, CancellationToken cancellationToken = default)
    {
        var idList = ids.Distinct().ToList();
        IEnumerable<TModel> cached = (await Repository.GetManyAsync(idList)).ToList();
        int cachedCount = cached.Count();

        if (cachedCount == idList.Count)
        {
            _logger.LogDebug("{Resource}: cache hit for all {IdCount} id(s)", ResourceName, idList.Count);
            return cached;
        }

        _logger.LogInformation(
            "{Resource}: cache had {CachedCount}/{IdCount} id(s); fetching full batch from API",
            ResourceName, cachedCount, idList.Count);

        // something was missing, refetch the whole batch from the API
        IExecutableGw2ApiRequest<IEnumerable<TModel>, TId> request = Request.GetBulk(idList);
        IEnumerable<TModel>? fetched = await Gateway.FetchAsync(request, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning(
                "{Resource}: bulk fetch returned null; falling back to {CachedCount} cached result(s)",
                ResourceName, cachedCount);
            return cached;
        }

        List<TModel> fetchedList = fetched.ToList();
        if (fetchedList.Count > 0)
        {
            await Repository.UpsertAllAsync(fetchedList);
            _logger.LogInformation("{Resource}: cached {FetchedCount} item(s) after bulk fetch", ResourceName, fetchedList.Count);
        }

        return fetchedList;
    }

    public async Task<IEnumerable<TModel>> GetAll(CancellationToken cancellationToken = default)
    {
        StaticMetaEntity? meta = await _staticMetaRepository.GetAsync(ResourceName);
        if (meta is { HasFetchedAll: true })
        {
            _logger.LogDebug("{Resource}: already fully synced (per cache_meta); skipping live id check", ResourceName);
            return await Repository.GetAllAsync();
        }

        IExecutableGw2ApiRequest<IEnumerable<TId>,TId> idsRequest = Request.GetAllIds();
        IEnumerable<TId>? allIds = await Gateway.FetchAsync(idsRequest, cancellationToken);
        if (allIds is null)
        {
            _logger.LogWarning("{Resource}: could not fetch live id list; returning cached data as-is", ResourceName);
            return await Repository.GetAllAsync();
        }

        List<TId> idList = allIds.ToList();
        List<TModel> cached = (await Repository.GetManyAsync(idList)).ToList();
        if (cached.Count == idList.Count)
        {
            _logger.LogDebug("{Resource}: cache complete for all {IdCount} live id(s)", ResourceName, idList.Count);
            await MarkFullySynced();
            return cached;
        }

        _logger.LogInformation(
            "{Resource}: cache incomplete ({CachedCount}/{IdCount}); refetching all from API",
            ResourceName, cached.Count, idList.Count);

        // cache incomplete relative to the live id set, repopulate everything
        IExecutableGw2ApiRequest<IEnumerable<TModel>,TId> allRequest = Request.GetAll();
        IEnumerable<TModel>? fetched = await Gateway.FetchAsync(allRequest, cancellationToken);
        if (fetched is null)
        {
            _logger.LogWarning(
                "{Resource}: full refetch returned null; falling back to {CachedCount} cached result(s)",
                ResourceName, cached.Count);
            return cached;
        }

        List<TModel> fetchedList = fetched.ToList();
        await Repository.UpsertAllAsync(fetchedList);
        await MarkFullySynced();
        _logger.LogInformation("{Resource}: cached {FetchedCount} item(s) after full refetch", ResourceName, fetchedList.Count);
        return fetchedList;
    }

    // FetchedAllBuildId is left at its default (0) — there's no live build-id check wired up yet,
    // so HasFetchedAll currently never gets invalidated automatically. Clear the static_meta row
    // for a resource manually if it ever needs to be resynced.
    private Task MarkFullySynced() => _staticMetaRepository.UpsertAsync(new StaticMetaEntity
    {
        Id = ResourceName,
        HasFetchedAll = true,
        FetchedAllAt = DateTime.UtcNow
    });

    public async Task<IEnumerable<TId>?> GetIds(CancellationToken cancellationToken = default)
    {
        _logger.LogDebug("{Resource}: fetching live id list from API", ResourceName);
        IEnumerable<TId>? ids = await Gateway.FetchAsync(Request.GetAllIds(), cancellationToken);
        if (ids is null)
        {
            _logger.LogWarning("{Resource}: fetch for live id list returned null", ResourceName);
            return null;
        }

        int idCount = ids.Count();
        _logger.LogInformation("{Resource}: fetched {IdCount} live id(s) from API", ResourceName, idCount);
        return ids;
    }

    public async Task<IEnumerable<TId>> GetCachedIds()
    {
        _logger.LogDebug("{Resource}: reading cached ids", ResourceName);
        List<TId> ids = (await Repository.GetCachedIdsAsync()).ToList();
        _logger.LogDebug("{Resource}: read {IdCount} cached id(s)", ResourceName, ids.Count);
        return ids;
    }
}
