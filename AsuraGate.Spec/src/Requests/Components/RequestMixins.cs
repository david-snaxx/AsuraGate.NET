namespace AsuraGate.Spec.Requests.Components;

public static class ClientMixins
{
    public static IExecutableGw2ApiRequest<TModel, TId> GetById<TModel, TId>(this IGetsSingle<TModel, TId> request, TId id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id));
        return new ExecutableGw2ApiRequest<TModel, TId>
        {
            BaseRequest = request, 
            IdParamKey = request.SingleIdParamName,
            IdValues = new List<TId> { id }
        };
    }

    public static IExecutableGw2ApiRequest<TModel, TId> GetObject<TModel, TId>(this IGetsSingleNoId<TModel> request)
    {
        return new ExecutableGw2ApiRequest<TModel, TId>
        {
            BaseRequest = request
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>, TId> GetBulk<TModel, TId>(
        this IGetsBulk<TModel, TId> request, IEnumerable<TId> ids)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>, TId>
        {
            BaseRequest = request, 
            IdParamKey = request.BulkIdParamName,
            IdValues = ids
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TId>, TId> GetAllIds<TId>(this IGetsIds<TId> request)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TId>, TId>()
        {
            BaseRequest = request
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>, TId> GetAll<TModel, TId>(this IGetsAll<TModel, TId> request)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>, TId>()
        {
            BaseRequest = request,
            IsGetAllRequest = true
        };
    }

    public static IExecutableGw2ApiRequest<IEnumerable<TModel>, TId> GetPage<TModel, TId>(this IPaginated<TModel> request,
        int page, int pageSize)
    {
        return new ExecutableGw2ApiRequest<IEnumerable<TModel>, TId>()
        {
            BaseRequest = request,
            ExtraQueryParams = new List<KeyValuePair<string, string>>(){
                new KeyValuePair<string, string>("page", page.ToString()),
                new KeyValuePair<string, string>("page_size", pageSize.ToString()) }
        };
    }
}
