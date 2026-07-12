using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using AsuraGate.Spec.Requests.Components;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

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

    // GW2's rate limit is a token bucket: 300 burst, refilling at 5/sec (see API:Best_practices).
    // A bulk/get-all request can fan out into hundreds of chunk requests fired at once; without a
    // cap here that burst blows straight through the bucket and comes back as a wall of 429s.
    private const int MaxConcurrentRequests = 10;
    private readonly SemaphoreSlim _concurrencyLimiter = new(MaxConcurrentRequests);

    // GW2 does not document a Retry-After header on 429s, so retries use blind exponential
    // backoff (with jitter to avoid every stalled request retrying in lockstep) instead.
    private const int MaxRetries = 5;
    private static readonly TimeSpan BaseRetryDelay = TimeSpan.FromSeconds(1);

    private Gw2ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<TModel?> GetAsync<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context = null,
        ILogger? logger = null,
        CancellationToken cancellationToken = default)
    {
        logger ??= NullLogger.Instance;
        string endpoint = request.BaseRequest.EndpointUrl;
        Stopwatch stopwatch = Stopwatch.StartNew();

        try
        {
            TModel? result;
            if (request.IsGetAllRequest)
            {
                logger.LogInformation("Starting get-all request for {Endpoint}", endpoint);
                result = await HandleGetAllRequest(request, context, logger, cancellationToken);
            }
            else
            {
                int idCount = request.IdValues.Count();
                if (idCount == 1)
                {
                    logger.LogInformation("Starting single request for {Endpoint}", endpoint);
                    result = await HandleSingleRequest(request, context, logger, cancellationToken);
                }
                else if (idCount > 1)
                {
                    logger.LogInformation("Starting bulk request for {Endpoint} ({IdCount} ids)", endpoint, idCount);
                    result = await HandleBulkRequest(request, request.IdValues, request.IdParamKey, context, logger, cancellationToken);
                }
                else
                {
                    logger.LogInformation("Starting no-id request for {Endpoint}", endpoint);
                    result = await HandleNoIdRequest(request, context, logger, cancellationToken);
                }
            }

            logger.LogInformation("Completed request for {Endpoint} in {ElapsedMs}ms", endpoint, stopwatch.ElapsedMilliseconds);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Request for {Endpoint} failed after {ElapsedMs}ms", endpoint, stopwatch.ElapsedMilliseconds);
            throw;
        }
    }

    private async Task<TModel?> HandleSingleRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        TId firstId = request.IdValues.First();
        if (firstId is null) throw new ArgumentNullException(nameof(firstId));
        KeyValuePair<string, string> idParam = new KeyValuePair<string, string>(request.IdParamKey, firstId.ToString()!);

        IEnumerable<KeyValuePair<string, string>> queryParams = request.ExtraQueryParams.Union([idParam]);
        Uri uri = BuildUri(request.BaseRequest.EndpointUrl, queryParams);
        return await FetchOneAsync<TModel>(uri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, logger, cancellationToken);
    }

    // Requests that need no ID at all (e.g. GetObject, GetPage, GuildMixins.Search, CommerceMixins.Calculate)
    private async Task<TModel?> HandleNoIdRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        Uri uri = BuildUri(request.BaseRequest.EndpointUrl, request.ExtraQueryParams);
        return await FetchOneAsync<TModel>(uri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, logger, cancellationToken);
    }

    private async Task<TModel?> HandleBulkRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        IEnumerable<TId> idValues,
        string idParamKey,
        Gw2ApiRequestContext? context,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        List<Uri> uris = idValues.Chunk(200)
            .Select(idBatch => BuildUri(
                request.BaseRequest.EndpointUrl,
                request.ExtraQueryParams.Union([new KeyValuePair<string, string>(idParamKey, string.Join(",", idBatch))])))
            .ToList();

        logger.LogInformation("Bulk request for {Endpoint} split into {ChunkCount} chunk(s) of up to 200 ids",
            request.BaseRequest.EndpointUrl, uris.Count);

        return await FetchAndMergeAsync<TModel>(uris, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, logger, cancellationToken);
    }

    private async Task<TModel?> HandleGetAllRequest<TModel, TId>(
        IExecutableGw2ApiRequest<TModel, TId> request,
        Gw2ApiRequestContext? context,
        ILogger logger,
        CancellationToken cancellationToken = default)
    {
        // Calling the endpoint with no id params returns just the list of all valid ids;
        // the full objects have to be fetched afterwards via a chunked bulk request.
        logger.LogInformation("Fetching all ids for {Endpoint} before bulk-fetching objects", request.BaseRequest.EndpointUrl);
        Uri idsUri = BuildUri(request.BaseRequest.EndpointUrl, request.ExtraQueryParams);
        IEnumerable<TId>? ids = await FetchOneAsync<IEnumerable<TId>>(
            idsUri, request.BaseRequest.IsAuthenticated, request.BaseRequest.IsLocalized, context, logger, cancellationToken);
        if (ids is null)
        {
            logger.LogWarning("Id list for {Endpoint} came back null; returning default", request.BaseRequest.EndpointUrl);
            return default;
        }

        List<TId> idList = ids.ToList();
        logger.LogInformation("Retrieved {IdCount} ids for {Endpoint}", idList.Count, request.BaseRequest.EndpointUrl);

        return await HandleBulkRequest(request, idList, "ids", context, logger, cancellationToken);
    }

    private async Task<TModel?> FetchOneAsync<TModel>(
        Uri uri, bool isAuthenticated, bool isLocalized, Gw2ApiRequestContext? context, ILogger logger, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await ExecuteHttpRequestAsync(
            () => BuildRequestMessage(uri, isAuthenticated, isLocalized, context), uri, logger, cancellationToken);
        response.EnsureSuccessStatusCode();
        return await JsonSerializer.DeserializeAsync<TModel>(
            await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
    }

    // Each uri returns its own JSON array (the GW2 API caps id lists at 200 per call); when more than
    // one batch is needed the arrays are concatenated before being deserialized as a single TModel.
    private async Task<TModel?> FetchAndMergeAsync<TModel>(
        List<Uri> uris, bool isAuthenticated, bool isLocalized, Gw2ApiRequestContext? context, ILogger logger, CancellationToken cancellationToken)
    {
        if (uris.Count == 0)
        {
            logger.LogInformation("No ids to fetch; returning an empty result");
            return await DeserializeAsync<TModel>("[]", cancellationToken);
        }
        if (uris.Count == 1) return await FetchOneAsync<TModel>(uris[0], isAuthenticated, isLocalized, context, logger, cancellationToken);

        HttpResponseMessage[] responses = await Task.WhenAll(uris.Select(uri =>
            ExecuteHttpRequestAsync(() => BuildRequestMessage(uri, isAuthenticated, isLocalized, context), uri, logger, cancellationToken)));

        List<JsonElement> mergedElements = new List<JsonElement>();
        foreach (HttpResponseMessage response in responses)
        {
            response.EnsureSuccessStatusCode();
            using JsonDocument document = await JsonDocument.ParseAsync(
                await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken: cancellationToken);
            mergedElements.AddRange(document.RootElement.EnumerateArray().Select(e => e.Clone()));
        }

        logger.LogInformation("Merged {ChunkCount} chunk response(s) into {ElementCount} total element(s)",
            responses.Length, mergedElements.Count);

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

    private async Task<HttpResponseMessage> ExecuteHttpRequestAsync(
        Func<HttpRequestMessage> requestFactory, Uri uri, ILogger logger, CancellationToken cancellationToken)
    {
        int available = _concurrencyLimiter.CurrentCount;
        Stopwatch waitStopwatch = Stopwatch.StartNew();
        if (available == 0)
            logger.LogInformation("All {MaxConcurrentRequests} request slots busy; queuing {Uri}", MaxConcurrentRequests, uri);

        await _concurrencyLimiter.WaitAsync(cancellationToken);
        try
        {
            if (waitStopwatch.ElapsedMilliseconds > 10)
            {
                logger.LogInformation("{Uri} waited {WaitMs}ms for a free request slot", uri.GetLeftPart(UriPartial.Path), waitStopwatch.ElapsedMilliseconds);
                logger.LogDebug("Full request URL: {Url}", uri);
            }
            return await SendWithRetryAsync(requestFactory, uri, logger, cancellationToken);
        }
        finally
        {
            _concurrencyLimiter.Release();
        }
    }

    private async Task<HttpResponseMessage> SendWithRetryAsync(
        Func<HttpRequestMessage> requestFactory, Uri uri, ILogger logger, CancellationToken cancellationToken)
    {
        for (int attempt = 0; ; attempt++)
        {
            Stopwatch attemptStopwatch = Stopwatch.StartNew();
            logger.LogInformation("Sending GET {Uri} (attempt {Attempt}/{MaxAttempts})", uri.GetLeftPart(UriPartial.Path), attempt + 1, MaxRetries + 1);
            logger.LogDebug("Full request URL: {Url}", uri);
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(requestFactory(), cancellationToken);
            }
            catch (HttpRequestException ex) when (attempt < MaxRetries)
            {
                TimeSpan delay = GetRetryDelay(attempt);
                logger.LogWarning(ex, "Network error sending {Uri} after {ElapsedMs}ms (attempt {Attempt}); retrying in {DelayMs}ms",
                    uri, attemptStopwatch.ElapsedMilliseconds, attempt + 1, delay.TotalMilliseconds);
                await Task.Delay(delay, cancellationToken);
                continue;
            }

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                if (attempt >= MaxRetries)
                {
                    logger.LogError("Rate limit hit for {Uri} and retries exhausted after {Attempts} attempt(s), {ElapsedMs}ms",
                        uri, attempt + 1, attemptStopwatch.ElapsedMilliseconds);
                    return response;
                }
                TimeSpan delay = GetRetryDelay(attempt);
                logger.LogWarning("Rate limit (429) hit for {Uri} (attempt {Attempt}); backing off {DelayMs}ms before retry",
                    uri, attempt + 1, delay.TotalMilliseconds);
                response.Dispose();
                await Task.Delay(delay, cancellationToken);
                continue;
            }

            if ((int)response.StatusCode >= 500 && attempt < MaxRetries)
            {
                TimeSpan delay = GetRetryDelay(attempt);
                logger.LogWarning("Server error {StatusCode} for {Uri} after {ElapsedMs}ms (attempt {Attempt}); retrying in {DelayMs}ms",
                    (int)response.StatusCode, uri, attemptStopwatch.ElapsedMilliseconds, attempt + 1, delay.TotalMilliseconds);
                response.Dispose();
                await Task.Delay(delay, cancellationToken);
                continue;
            }

            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("Succeeded {StatusCode} for {Uri} in {ElapsedMs}ms (attempt {Attempt})",
                    (int)response.StatusCode, uri.GetLeftPart(UriPartial.Path), attemptStopwatch.ElapsedMilliseconds, attempt + 1);
                logger.LogDebug("Full request URL: {Url}", uri);
            }
            else
            {
                logger.LogError("Failed {StatusCode} for {Uri} after {ElapsedMs}ms (attempt {Attempt}, not retrying)",
                    (int)response.StatusCode, uri, attemptStopwatch.ElapsedMilliseconds, attempt + 1);
            }

            return response;
        }
    }

    private static TimeSpan GetRetryDelay(int attempt)
    {
        TimeSpan delay = BaseRetryDelay * Math.Pow(2, attempt);
        TimeSpan jitter = TimeSpan.FromMilliseconds(Random.Shared.Next(0, 250));
        return delay + jitter;
    }
}
