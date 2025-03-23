using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class GetGameResponse
{
    [JsonPropertyName("jeu")]
    public Game? Game { get; set; }
}
