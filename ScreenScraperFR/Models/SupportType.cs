using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class SupportTypesResponse
{
    [JsonPropertyName("supporttypes")]
    public List<String> SupportTypes { get; set; } = [];
}
