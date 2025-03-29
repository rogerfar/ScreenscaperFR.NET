using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace ScreenScraperFR;

internal class Requests(HttpClient httpClient, Store store)
{
    private static JsonSerializerOptions JsonSerializerSettings => new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    private async Task<Byte[]?> TextRequest(String url, Boolean requireAuthentication, IDictionary<String, String>? parameters, CancellationToken cancellationToken) 
    {
        url = $"{Store.API_URL}{Store.API_VERSION}{url}?output=json&softname={HttpUtility.UrlEncode(store.Softname)}&devid={store.DevId}&devpassword={store.DevPassword}";
        
        if (requireAuthentication)
        {
            url = $"{url}&ssid={store.UserName}&sspassword={store.UserPassword}";
        }

        if (parameters is {Count: > 0})
        {
            var parametersString = String.Join("&", parameters.Select(m => $"{m.Key}={HttpUtility.UrlEncode(m.Value)}"));

            url = $"{url}&{parametersString}";
        }

        var response = await httpClient.GetAsync(url, cancellationToken);

        if (response.StatusCode == HttpStatusCode.NoContent)
        {
            return null;
        }

        var buffer = await response.Content.ReadAsByteArrayAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            var error = text.Trim();

            throw new ScreenScraperFRException(error, (Int32) response.StatusCode);
        }

        return buffer;
    }

    public async Task<T> GetRequestAsync<T>(String url, Boolean requireAuthentication, IDictionary<String, String>? parameters, CancellationToken cancellationToken)
        where T : class, new()
    {
        var request = await TextRequest(url, requireAuthentication, parameters, cancellationToken);

        if (request == null)
        {
            return new();
        }

        var requestResult = Encoding.UTF8.GetString(request, 0, request.Length);

        try
        {
            var result = JsonSerializer.Deserialize<Response<T>>(requestResult, JsonSerializerSettings) ?? throw new("Response was null");

            if (!result.Header.Success)
            {
                if (result.Header.Error != null && !String.IsNullOrWhiteSpace(result.Header.Error))
                {
                    throw new ScreenScraperFRException(result.Header.Error, 500);
                }

                throw new($"Unknown error. Response was: {result}");
            }

            if (result.Data == null)
            {
                return new();
            }

            return result.Data;
        }
        catch (ScreenScraperFRException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new($"Unable to deserialize ScreenScraper.fr API response to {typeof(T).Name}. Response was: {requestResult}", ex);
        }
    }

    public async Task<MediaResponse> GetMediaRequestAsync(String url, String destinationPath, Boolean requireAuthentication, IDictionary<String, String>? parameters, EventHandler<DownloadProgressEventArgs>? progressEvent, CancellationToken cancellationToken)
    {
        url = $"{Store.API_URL}{Store.API_VERSION}{url}?output=json&softname={HttpUtility.UrlEncode(store.Softname)}&devid={store.DevId}&devpassword={store.DevPassword}";
        
        if (requireAuthentication)
        {
            url = $"{url}&ssid={store.UserName}&sspassword={store.UserPassword}";
        }

        if (parameters is {Count: > 0})
        {
            var parametersString = String.Join("&", parameters.Select(m => $"{m.Key}={HttpUtility.UrlEncode(m.Value)}"));

            url = $"{url}&{parametersString}";
        }
        
        using var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        response.EnsureSuccessStatusCode();

        var mediaType = response.Content.Headers.ContentType?.MediaType;
        
        if (mediaType == "text/html")
        {
            var textBytesResponse = await response.Content.ReadAsByteArrayAsync(cancellationToken);

            var resultMessage = Encoding.UTF8.GetString(textBytesResponse, 0, textBytesResponse.Length).Trim().ToUpper();

            return resultMessage switch
            {
                "CRCOK" => MediaResponse.CrcOk,
                "MD5OK" => MediaResponse.Md5Ok,
                "SHA1OK" => MediaResponse.Sha1Ok,
                "NOMEDIA" => MediaResponse.Nomedia,
                _ => throw new($"Unknown media response: {resultMessage}")
            };
        }

        var totalBytes = response.Content.Headers.ContentLength ?? -1L;

        await using var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);

        await using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true);

        var buffer = new Byte[81920];
        Int64 totalBytesRead = 0;
        Int32 bytesRead;
        var sw = System.Diagnostics.Stopwatch.StartNew();

        while ((bytesRead = await contentStream.ReadAsync(buffer, cancellationToken)) > 0)
        {
            await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead), cancellationToken);

            totalBytesRead += bytesRead;

            if (totalBytes > 0)
            {
                var speedMbps = totalBytesRead / 1024.0 / 1024.0 / sw.Elapsed.TotalSeconds;

                progressEvent?.Invoke(null, new(totalBytesRead, totalBytes, speedMbps));
            }
        }

        return MediaResponse.Ok;
    }
}