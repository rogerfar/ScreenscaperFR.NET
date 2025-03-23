using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class RomTypesResponse
{
    [JsonPropertyName("romtypes")]
    public List<String> RomTypes { get; set; } = [];
}
