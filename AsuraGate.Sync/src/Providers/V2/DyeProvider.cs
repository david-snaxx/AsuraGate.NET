using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.StaticCache.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class DyeProvider : Provider<Dye, int, DyeRepository, DyeRequest>
{
    public DyeProvider(DyeRepository repository, DyeRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }

    public Task<IEnumerable<Dye>> GetByCategoryAsync(string category) => Repository.GetByCategoryAsync(category);
}
