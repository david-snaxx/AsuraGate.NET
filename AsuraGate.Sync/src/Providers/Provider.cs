using AsuraGate.Gateway;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.StaticCache;
using AsuraGate.StaticCache.Repositories;

namespace AsuraGate.Sync.Providers;

public class Provider<TModel, TId, TRepository, TRequest>
    where TRepository : IStaticCacheRepository<TModel, TId>
    where TRequest : IGetsSingle<TModel, TId>, IGetsBulk<TModel, TId>, IGetsAll<TModel, TId>, IGetsIds<TId>
{
    protected TRepository Repository { get; }
    protected TRequest Request { get; }
    protected Gw2ApiGateway Gateway { get; }

    public Provider(TRepository repository, TRequest request, Gw2ApiGateway gateway)
    {
        Repository = repository;
        Request = request;
        Gateway = gateway;
    }
    
    public async Task<TModel?> GetById(TId id)
    {
        TModel? cached = await Repository.GetAsync(id);
        if (cached is not null) return cached;
        
        // cache miss
        IExecutableGw2ApiRequest<TModel, TId> request = Request.GetById(id);
        TModel? fetched = await Gateway.FetchAsync(request);
        if (fetched is null) return default;
        
        // fill cache with missing data
       await Repository.UpsertAsync(fetched);
       
       return fetched;
    }

    public async Task<IEnumerable<TModel?>> GetBulk(IEnumerable<TId> ids)
    {
        var idList = ids.Distinct().ToList();
        IEnumerable<TModel?> cached = (await Repository.GetManyAsync(idList)).ToList();

        if (cached.Count() == idList.Count) return cached;

        // something was missing, refetch the whole batch from the API
        IExecutableGw2ApiRequest<IEnumerable<TModel>, TId> request = Request.GetBulk(idList);
        IEnumerable<TModel>? fetched = await Gateway.FetchAsync(request);
        if (fetched is null) return cached;

        List<TModel> fetchedList = fetched.ToList();
        if (fetchedList.Count > 0)
        {
            await Repository.UpsertAllAsync(fetchedList);
        }

        return fetchedList;
    }

    public async Task<IEnumerable<TModel>> GetAll()
    {
        IExecutableGw2ApiRequest<IEnumerable<TId>,TId> idsRequest = Request.GetAllIds();
        IEnumerable<TId>? allIds = await Gateway.FetchAsync(idsRequest);
        if (allIds is null) return await Repository.GetAllAsync();

        List<TId> idList = allIds.ToList();
        List<TModel> cached = (await Repository.GetManyAsync(idList)).ToList();
        if (cached.Count == idList.Count) return cached;

        // cache incomplete relative to the live id set, repopulate everything
        IExecutableGw2ApiRequest<IEnumerable<TModel>,TId> allRequest = Request.GetAll();
        IEnumerable<TModel>? fetched = await Gateway.FetchAsync(allRequest);
        if (fetched is null) return cached;

        List<TModel> fetchedList = fetched.ToList();
        await Repository.UpsertAllAsync(fetchedList);
        return fetchedList;
    }

    public Task<IEnumerable<TId>?> GetIds() => Gateway.FetchAsync(Request.GetAllIds());
    
    public Task<IEnumerable<TId>> GetCachedIds() => Repository.GetCachedIdsAsync();
}