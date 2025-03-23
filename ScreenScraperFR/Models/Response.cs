using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class Response<T> where T : class, new()
{
    [JsonPropertyName("header")]
    public required ResponseHeader Header { get; init; }

    [JsonPropertyName("response")]
    public T? Data { get; init; }
}

internal class ResponseHeader
{
    [JsonPropertyName("success")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public required Boolean Success { get; set; }

    [JsonPropertyName("error")]
    public String? Error { get; set; }
}