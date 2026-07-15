using AsuraGate.Gateway;
using Microsoft.Extensions.Logging;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Requests.V2;
using AsuraGate.Persistence.Static.Repositories.V2;

namespace AsuraGate.Sync.Providers.V2;

public class MailCarrierProvider : Provider<MailCarrier, int, MailCarrierRepository, MailCarrierRequest>
{
    public MailCarrierProvider(MailCarrierRepository repository, MailCarrierRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
        : base(repository, request, gateway, logger)
    {
    }
}
