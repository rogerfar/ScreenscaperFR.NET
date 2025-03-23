using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class RegionsResponse
{
    [JsonPropertyName("regions")]
    public Dictionary<Int32, Region> Regions { get; set; } = new();
}

public class Region
{
    /// <summary>
    /// Numeric identifier of the region.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name of the region (code).
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public required String ShortName { get; set; }

    /// <summary>
    /// Name of the region in French.
    /// </summary>
    [JsonPropertyName("nom_fr")]
    public required String Fr { get; set; }

    /// <summary>
    /// Name of the region in German.
    /// </summary>
    [JsonPropertyName("nom_de")]
    public String? De { get; set; }

    /// <summary>
    /// Name of the region in English.
    /// </summary>
    [JsonPropertyName("nom_en")]
    public String? En { get; set; }

    /// <summary>
    /// Name of the region in Spanish.
    /// </summary>
    [JsonPropertyName("nom_es")]
    public String? Es { get; set; }

    /// <summary>
    /// Name of the region in Italian.
    /// </summary>
    [JsonPropertyName("nom_it")]
    public String? It { get; set; }

    /// <summary>
    /// Name of the region in Portuguese.
    /// </summary>
    [JsonPropertyName("nom_pt")]
    public String? Pt { get; set; }

    /// <summary>
    /// Identifier of the parent region (0 if it’s a top-level region).
    /// </summary>
    [JsonPropertyName("parent")]
    public Int32 ParentId { get; set; }

    /// <summary>
    /// Media files associated with the region (e.g., icons, backgrounds).
    /// </summary>
    [JsonPropertyName("medias")]
    public Dictionary<String, String>? Media { get; set; }
}
