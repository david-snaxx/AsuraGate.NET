namespace AsuraGate.Gateway.Requests.Components;

public static class ClientMixins
{
    public static IExecutableGw2ApiRequest<TModel> GetById<TModel, TId>(
        this IGetsSingle<TModel, TId> request,
        TId id,
        CancellationToken ct = default)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        return new ExecutableGw2ApiRequest<TModel>
        {
            BaseRequest = request, 
            ExtraQueryParameters = [new KeyValuePair<string, string>("id", id.ToString()!)]
        };
    }
    
    public static IExecutableGw2ApiRequest<IEnumerable<TModel>> GetBulk<TModel>()
}
