using AsuraGate.Spec.Requests.V2.Guild;

namespace AsuraGate.Spec.Requests.Components;

public static class GuildMixins
{
    public static IExecutableGw2ApiRequest<IEnumerable<string>, string> Search(
        this GuildSearchRequest request,
        string guildName)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<string>, string>
        {
            BaseRequest = request,
            ExtraQueryParams = new List<KeyValuePair<string, string>>(){
                new KeyValuePair<string, string>("name", guildName) }
        };
    }
}