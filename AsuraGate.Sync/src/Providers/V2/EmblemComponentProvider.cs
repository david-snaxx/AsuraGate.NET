using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.StaticCache.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class EmblemComponentProvider<TRequest>
    where TRequest : IGetsSingle<EmblemComponent, int>, IGetsAll<EmblemComponent, int>
{
    private readonly string _slot;
    private readonly EmblemComponentRepository _repository;
    private readonly TRequest _request;
    private readonly Gw2ApiGateway _gateway;

    public EmblemComponentProvider(string slot, EmblemComponentRepository repository, TRequest request, Gw2ApiGateway gateway)
    {
        _slot = slot;
        _repository = repository;
        _request = request;
        _gateway = gateway;
    }

    public async Task<EmblemComponent?> GetByIdAsync(int componentId)
    {
        EmblemComponent? cached = await _repository.GetAsync(_slot, componentId);
        if (cached is not null) return cached;

        IExecutableGw2ApiRequest<EmblemComponent, int> request = _request.GetById(componentId);
        EmblemComponent? fetched = await _gateway.FetchAsync(request);
        if (fetched is null) return null;

        await _repository.UpsertAsync(_slot, fetched);
        return fetched;
    }
}
