namespace AsuraGate.Gateway.Requests.Components;

public static class ClientMixins
{
    public static IExecutableGw2ApiRequest<TModel> GetById<TModel, TId>(this IGetsSingle<TModel, TId> request, TId id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        return new ExecutableGw2ApiRequest<TModel>
        {
            BaseRequest = request, 
            ExtraQueryParameters = [new KeyValuePair<string, string>("id", id.ToString()!)]
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>> GetBulk<TModel, TId>(
        this IGetsBulk<TModel, TId> request, IEnumerable<TId> ids)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>>
        {
            BaseRequest = request, 
            ExtraQueryParameters = [new KeyValuePair<string, string>("ids", string.Join(",", ids))]
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TId>> GetAllIds<TId>(this IGetsIds<TId> request)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TId>>()
        {
            BaseRequest = request
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>> GetAll<TModel>(this IGetsAll<TModel> request)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>>()
        {
            BaseRequest = request,
            IsGetAllRequest = true
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>> GetPage<TModel>(this IPaginated<TModel> request,
        int page, int pageSize)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>>()
        {
            BaseRequest = request,
            ExtraQueryParameters =
            [
                new KeyValuePair<string, string>("page", page.ToString()),
                new KeyValuePair<string, string>("page_size", pageSize.ToString())
            ]
        };
    }
}
