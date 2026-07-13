using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Spec.Requests.Components;
using AsuraGate.StaticCache.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class BuildProvider
{
    private readonly BuildRepository _repository;
    private readonly BuildRequest _request;
    private readonly Gw2ApiGateway _gateway;

    public BuildProvider(BuildRepository repository, BuildRequest request, Gw2ApiGateway gateway)
    {
        _repository = repository;
        _request = request;
        _gateway = gateway;
    }

    public async Task<Build?> GetCurrentAsync()
    {
        IExecutableGw2ApiRequest<Build, object> request = _request.GetObject<Build, object>();
        Build? fetched = await _gateway.FetchAsync(request);
        if (fetched is null) return null;

        await _repository.UpsertAsync(fetched);
        return fetched;
    }
}
