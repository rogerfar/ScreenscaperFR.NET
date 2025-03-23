using System.Text.Json.Serialization;


namespace ScreenScraperFR;

internal class PlayerCountsResponse
{
    [JsonPropertyName("nbjoueurs")]
    public Dictionary<String, PlayerCount> PlayerCounts { get; set; } = [];
}

public class PlayerCount
{
    /// <summary>
    /// Numeric ID of the player count.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Label/description of the number of players.
    /// </summary>
    [JsonPropertyName("nom")]
    public required String Name { get; set; }

    /// <summary>
    /// ID of the parent player count (0 if no parent).
    /// </summary>
    [JsonPropertyName("parent")]
    public Int32 ParentId { get; set; }
}
