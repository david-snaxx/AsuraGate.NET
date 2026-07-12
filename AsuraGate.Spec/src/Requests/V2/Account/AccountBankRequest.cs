using AsuraGate.Spec.Consts;
using AsuraGate.Spec.Models.V2;
using AsuraGate.Spec.Models.V2.Account;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Spec.Requests.V2.Account;

public sealed class AccountBankRequest :
    IGetsSingle<AccountBankItem, int>,
    IGetsBulk<AccountBankItem, int>,
    IGetsAll<AccountBankItem, int>,
    IPaginated<AccountBankItem>
{
    public string EndpointUrl { get; } = Gw2ApiEndpointUrl.AccountBank;
    public bool IsAuthenticated { get; } = true;
    public bool IsLocalized { get; } = false;
}
