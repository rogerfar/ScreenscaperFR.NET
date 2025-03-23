using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class GenresResponse
{
    [JsonPropertyName("genres")]
    public Dictionary<Int32, Genre> Genres { get; set; } = new();
}

public class Genre
{
    /// <summary>
    /// Numeric identifier of the genre.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Name of the genre in French.
    /// </summary>
    [JsonPropertyName("nom_fr")]
    public required String Fr { get; set; }

    /// <summary>
    /// Name of the genre in English.
    /// </summary>
    [JsonPropertyName("nom_en")]
    public String? En { get; set; }

    /// <summary>
    /// Name of the genre in German.
    /// </summary>
    [JsonPropertyName("nom_de")]
    public String? De { get; set; }

    /// <summary>
    /// Name of the genre in Spanish.
    /// </summary>
    [JsonPropertyName("nom_es")]
    public String? Es { get; set; }

    /// <summary>
    /// Name of the genre in Italian.
    /// </summary>
    [JsonPropertyName("nom_it")]
    public String? It { get; set; }

    /// <summary>
    /// Name of the genre in Portuguese.
    /// </summary>
    [JsonPropertyName("nom_pt")]
    public String? Pt { get; set; }

    /// <summary>
    /// ID of the parent genre (0 if it's a top-level genre).
    /// </summary>
    [JsonPropertyName("parent")]
    public Int32 ParentId { get; set; }

    /// <summary>
    /// Media files associated with the genre (e.g., icons, backgrounds).
    /// </summary>
    [JsonPropertyName("medias")]
    public Dictionary<String, String>? Media { get; set; }
}
