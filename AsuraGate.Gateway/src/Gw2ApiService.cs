using System.Net.Http.Headers;
using System.Text.Json;
using AsuraGate.Spec.Requests.Components;

namespace AsuraGate.Gateway;

/// <summary>
/// Global, per-caller values that apply to every request regardless of endpoint shape.
/// Sent as headers so they never become part of the request URI.
/// </summary>
public sealed record Gw2ApiRequestContext(string? ApiKey = null, string? Localization = null, string? SchemaVersion = null);

public class Gw2ApiService
{
    private static readonly Lazy<Gw2ApiService> _instance = new(() => new Gw2ApiService());
    public static Gw2ApiService Instance => _instance.Value;
    private readonly HttpClient _httpClient;

    private Gw2ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TModel?> GetAsync<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context = null,
        CancellationToken cancellationToken = default)
    {
        if (request.IsGetAllRequest) return await HandleGetAllRequest(request, context, cancellationToken);

        int idCount = request.IdValues.Count();
        if (idCount == 1) return await HandleSingleRequest(request, context, cancellationToken);
        if (idCount > 1) return await HandleBulkRequest(request, request.IdValues, request.IdParamKey, context, cancellationToken);
        return await HandleNoIdRequest(request, context, cancellationToken);
    }

    private async Task<TModel?> HandleSingleRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        CancellationToken cancellationToken = default)
    {
        TId firstId = request.IdValues.First();
        if (firstId is null) throw new ArgumentNullException(nameof(firstId));
        KeyValuePair<string, string> idParam = new KeyValuePair<string, string>(request.IdParamKey, firstId.ToString()!);

        IEnumerable<KeyValuePair<string, string>> queryParams = request.ExtraQueryParams.Union([idParam]);
        Uri uri = BuildUri(request.BaseRequest.EndpointUrl, queryParams);
        return await FetchOneAsync<TModel>(uri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, cancellationToken);
    }

    // Requests that need no ID at all (e.g. GetObject, GetPage, GuildMixins.Search, CommerceMixins.Calculate)
    private async Task<TModel?> HandleNoIdRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        CancellationToken cancellationToken = default)
    {
        Uri uri = BuildUri(request.BaseRequest.EndpointUrl, request.ExtraQueryParams);
        return await FetchOneAsync<TModel>(uri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, cancellationToken);
    }

    private async Task<TModel?> HandleBulkRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        IEnumerable<TId> idValues,
        string idParamKey,
        Gw2ApiRequestContext? context,
        CancellationToken cancellationToken = default)
    {
        List<Uri> uris = idValues.Chunk(200)
            .Select(idBatch => BuildUri(
                request.BaseRequest.EndpointUrl,
                request.ExtraQueryParams.Union([new KeyValuePair<string, string>(idParamKey, string.Join(",", idBatch))])))
            .ToList();

        return await FetchAndMergeAsync<TModel>(uris, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, cancellationToken);
    }

    private async Task<TModel?> HandleGetAllRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        CancellationToken cancellationToken = default)
    {
        // Calling the endpoint with no id params returns just the list of all valid ids;
        // the full objects have to be fetched afterwards via a chunked bulk request.
        Uri idsUri = BuildUri(request.BaseRequest.EndpointUrl, request.ExtraQueryParams);
        IEnumerable<TId>? ids = await FetchOneAsync<IEnumerable<TId>>(
            idsUri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, cancellationToken);
        if (ids is null) return default;

        return await HandleBulkRequest(request, ids, "ids", context, cancellationToken);
    }

    private async Task<TModel?> FetchOneAsync<TModel>(
        Uri uri, bool isAuthenticated, bool isLocalized, Gw2ApiRequestContext? context, CancellationToken cancellationToken)
    {
        HttpRequestMessage requestMessage = BuildRequestMessage(uri, isAuthenticated, isLocalized, context);
        HttpResponseMessage response = await ExecuteHttpRequestAsync(requestMessage, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await JsonSerializer.DeserializeAsync<TModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    // Each uri returns its own JSON array (the GW2 API caps id lists at 200 per call); when more than
    // one batch is needed the arrays are concatenated before being deserialized as a single TModel.
    private async Task<TModel?> FetchAndMergeAsync<TModel>(
        List<Uri> uris, bool isAuthenticated, bool isLocalized, Gw2ApiRequestContext? context, CancellationToken cancellationToken)
    {
        if (uris.Count == 0) return await DeserializeAsync<TModel>("[]", cancellationToken);
        if (uris.Count == 1) return await FetchOneAsync<TModel>(uris[0], isAuthenticated, isLocalized, context, cancellationToken);

        IEnumerable<HttpRequestMessage> requests = uris.Select(uri =>
            BuildRequestMessage(uri, isAuthenticated, isLocalized, context));
        HttpResponseMessage[] responses = await Task.WhenAll(requests.Select(r => ExecuteHttpRequestAsync(r, cancellationToken)));

        List<JsonElement> mergedElements = new List<JsonElement>();
        foreach (HttpResponseMessage response in responses)
        {
            response.EnsureSuccessStatusCode();
            using JsonDocument document = await JsonDocument.ParseAsync(
                await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
            mergedElements.AddRange(document.RootElement.EnumerateArray().Select(e => e.Clone()));
        }

        using MemoryStream stream = new MemoryStream();
        using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
        {
            writer.WriteStartArray();
            foreach (JsonElement element in mergedElements) element.WriteTo(writer);
            writer.WriteEndArray();
        }
        stream.Position = 0;
        return await JsonSerializer.DeserializeAsync<TModel>(stream, cancellationToken: cancellationToken);
    }

    private async Task<TModel?> DeserializeAsync<TModel>(string json, CancellationToken cancellationToken)
    {
        using MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json));
        return await JsonSerializer.DeserializeAsync<TModel>(stream, cancellationToken: cancellationToken);
    }

    // doesnt know or care about how many ids are in the request
    private Uri BuildUri(string baseUrl, IEnumerable<KeyValuePair<string, string>> queryParams)
    {
        if (queryParams == null || !queryParams.Any()) return new Uri(baseUrl);
        return new Uri(
            $"{baseUrl}?{string.Join("&", queryParams.Select(qp =>
                $"{Uri.EscapeDataString(qp.Key)}={Uri.EscapeDataString(qp.Value)}"))}"
        );
    }

    private HttpRequestMessage BuildRequestMessage(Uri uri, bool isAuthenticated, bool isLocalized, Gw2ApiRequestContext? context)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        if (context is null) return requestMessage;

        if (isAuthenticated && !string.IsNullOrEmpty(context.ApiKey))
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.ApiKey);

        if (isLocalized && !string.IsNullOrEmpty(context.Localization))
            requestMessage.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue(context.Localization));

        if (!string.IsNullOrEmpty(context.SchemaVersion))
            requestMessage.Headers.Add("X-Schema-Version", context.SchemaVersion);

        return requestMessage;
    }

    private async Task<HttpResponseMessage> ExecuteHttpRequestAsync(HttpRequestMessage requestMessage,
        CancellationToken cancellationToken)
    {
        return await _httpClient.SendAsync(requestMessage, cancellationToken);
    }
}
