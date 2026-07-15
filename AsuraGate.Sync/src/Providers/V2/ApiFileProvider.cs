using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class ApiFileProvider : Provider<ApiFile, string, ApiFileRepository, FileRequest>
{
    public ApiFileProvider(ApiFileRepository repository, FileRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
