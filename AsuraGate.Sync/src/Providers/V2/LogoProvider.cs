using AsuraGate.Gateway;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class LogoProvider : Provider<Logo, string, LogoRepository, LogoRequest>
{
    public LogoProvider(LogoRepository repository, LogoRequest request, Gw2ApiGateway gateway)
        : base(repository, request, gateway)
    {
    }
}
