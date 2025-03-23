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

    private async Task<(Byte[]? Buffer, String? ContentType)> Request(String url, Boolean requireAuthentication, IDictionary<String, String>? parameters, CancellationToken cancellationToken) 
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
            return (null, null);
        }

        var buffer = await response.Content.ReadAsByteArrayAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var text = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            var error = text.Trim();

            throw new ScreenScraperFRException(error, (Int32) response.StatusCode);
        }

        return (buffer, response.Content.Headers.ContentType?.MediaType);
    }
    
    public async Task<T> GetRequestAsync<T>(String url, Boolean requireAuthentication, IDictionary<String, String>? parameters, CancellationToken cancellationToken)
        where T : class, new()
    {
        var request = await Request(url, requireAuthentication, parameters, cancellationToken);

        if (request.Buffer == null)
        {
            return new();
        }

        var requestResult = Encoding.UTF8.GetString(request.Buffer, 0, request.Buffer.Length);

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

    public async Task<MediaResponse> GetMediaRequestAsync(String url, Boolean requireAuthentication, IDictionary<String, String>? parameters, CancellationToken cancellationToken)
    {
        var request = await Request(url, requireAuthentication, parameters, cancellationToken);

        if (request.ContentType == "text/html")
        {
            if (request.Buffer == null)
            {
                return new(null, null);
            }

            var resultMessage = Encoding.UTF8.GetString(request.Buffer, 0, request.Buffer.Length).Trim().ToUpper();

            return resultMessage switch
            {
                "CRCOK" => new(request.Buffer, MediaResponseType.CrcOk),
                "MD5OK" => new(request.Buffer, MediaResponseType.Md5Ok),
                "SHA1OK" => new(request.Buffer, MediaResponseType.Sha1Ok),
                "NOMEDIA" => new(request.Buffer, MediaResponseType.Nomedia),
                _ => throw new($"Unknown media response: {resultMessage}")
            };
        }

        return new(request.Buffer, null);
    }
}