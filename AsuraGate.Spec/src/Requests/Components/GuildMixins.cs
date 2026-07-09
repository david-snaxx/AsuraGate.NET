using AsuraGate.Spec.Requests.V2.Guild;

namespace AsuraGate.Spec.Requests.Components;

public static class GuildMixins
{
    public static IExecutableGw2ApiRequest<string> Search(
        this GuildSearchRequest request,
        string guildName)
    {
        return new ExecutableGw2ApiRequest<string>
        {
            BaseRequest = request,
            ExtraQueryParameters = [new KeyValuePair<string, string>("name", guildName)]
        };
    }
}