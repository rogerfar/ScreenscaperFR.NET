using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class MediaTypesResponse
{
    [JsonPropertyName("supporttypes")]
    public List<String> MediaTypes { get; set; } = [];
}
