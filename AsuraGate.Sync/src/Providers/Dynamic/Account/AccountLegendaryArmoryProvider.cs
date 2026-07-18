using AsuraGate.Gateway;
using AsuraGate.Persistence.Dynamic.Repositories.Account.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Spec.Requests.V2.Account;
using Microsoft.Extensions.Logging;

namespace AsuraGate.Sync.Providers.Dynamic.Account;

public class AccountLegendaryArmoryProvider(AccountLegendaryArmoryRepository repository, AccountLegendaryArmoryRequest request, Gw2ApiGateway gateway, ILogger? logger = null)
    : CollectionSnapshotProvider<AccountLegendaryItem, int, AccountLegendaryArmoryRepository, AccountLegendaryArmoryRequest>(repository, request, gateway, logger);
