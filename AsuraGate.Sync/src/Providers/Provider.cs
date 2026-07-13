using AsuraGate.Gateway;
using AsuraGate.Spec.Requests;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.StaticCache;
using AsuraGate.StaticCache.Repositories;

namespace AsuraGate.Sync.Providers;

internal class Provider<TModel, TId, TRepository, TRequest>
    where TRepository : IStaticCacheRepository<TModel, TId>
    where TRequest : IGetsSingle<TModel, TId>, IGetsBulk<TModel, TId>, IGetsAll<TModel, TId>, IGetsIds<TId>
{
    private readonly TRepository _repository;
    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;

    public Provider(TRepository repository, TRequest request, Gw2ApiGateway gateway)
    {
        _repository = repository;
        _request = request;
        _gateway = gateway;
    }
    
    public async Task<TModel?> GetById(TId id)
    {
        TModel? cache = await _repository.GetAsync(id);
        if (cache is not null) return cache;
        
        // cache miss
        IExecutableGw2ApiRequest<TModel, TId> request = _request.GetById(id);
        TModel? fetched = await _gateway.FetchAsync(request);
        if (fetched is null) return default;
        
        // fill cache with missing data
       await _repository.UpsertAsync(fetched);
       
       return fetched;
    }

    public async Task<IEnumerable<TModel?>> GetBulkById(IEnumerable<TId> ids)
    {
        return null;
    }
}