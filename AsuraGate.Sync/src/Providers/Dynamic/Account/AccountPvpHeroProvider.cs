using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Account.V2;
using AsuraGate.Spec.Requests.V2.Account;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Account;

public class AccountPvpHeroProvider(AccountPvpHeroRepository repository, AccountPvpHeroRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    : IdListSnapshotProvider<int, AccountPvpHeroRepository, AccountPvpHeroRequest>(repository, request, gateway, logger);
