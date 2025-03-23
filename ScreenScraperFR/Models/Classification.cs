using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class ClassificationsResponse
{
    [JsonPropertyName("classifications")]
    public Dictionary<Int32, Classification> Classifications { get; set; } = new();
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Classification
{
    /// <summary>
    /// Numeric ID of the classification.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name of the classification (e.g., PEGI:12, ESRB:T).
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public String ShortName { get; set; }

    /// <summary>
    /// Name in French (optional).
    /// </summary>
    [JsonPropertyName("nom_fr")]
    public String? NameFr { get; set; }

    /// <summary>
    /// Name in German (optional).
    /// </summary>
    [JsonPropertyName("nom_de")]
    public String? NameDe { get; set; }

    /// <summary>
    /// Name in English (optional).
    /// </summary>
    [JsonPropertyName("nom_en")]
    public String? NameEn { get; set; }

    /// <summary>
    /// Name in Spanish (optional).
    /// </summary>
    [JsonPropertyName("nom_es")]
    public String? NameEs { get; set; }

    /// <summary>
    /// Name in Italian (optional).
    /// </summary>
    [JsonPropertyName("nom_it")]
    public String? NameIt { get; set; }

    /// <summary>
    /// Name in Portuguese (optional).
    /// </summary>
    [JsonPropertyName("nom_pt")]
    public String? NamePt { get; set; }

    /// <summary>
    /// ID of the parent classification (0 if it's a top-level classification).
    /// </summary>
    [JsonPropertyName("parent")]
    public Int32 ParentId { get; set; }

    /// <summary>
    /// Associated media resources (e.g., pictograms).
    /// </summary>
    [JsonPropertyName("medias")]
    public Media? Medias { get; set; }
}
