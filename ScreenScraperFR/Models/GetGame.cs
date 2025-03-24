using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class GetGameResponse
{
    [JsonPropertyName("jeu")]
    public Game? Game { get; set; }

    [JsonPropertyName("serveurs")]
    public ServerInfrastructureInfo? ServerInfrastructureInfo { get; set; } = new();

    [JsonPropertyName("ssuser")]
    public UserInfo? UserInfo { get; set; }
}
