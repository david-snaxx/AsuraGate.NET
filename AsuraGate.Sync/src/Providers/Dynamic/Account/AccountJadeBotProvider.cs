using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Account.V2;
using AsuraGate.Spec.Requests.V2.Account;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Account;

public class AccountJadeBotProvider(AccountJadeBotRepository repository, AccountJadeBotRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    : IdListSnapshotProvider<int, AccountJadeBotRepository, AccountJadeBotRequest>(repository, request, gateway, logger);
