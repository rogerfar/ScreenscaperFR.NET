using System.Text.Json.Serialization;

namespace ScreenScraperFR;

/// <summary>
/// Response containing a list of games returned by a search.
/// </summary>
internal class SearchGamesResponse
{
    [JsonPropertyName("jeux")]
    public List<Game> Games { get; set; } = [];
}
