using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class LanguagesResponse
{
    [JsonPropertyName("langues")]
    public Dictionary<Int32, Language> Languages { get; set; } = new();
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Language
{
    /// <summary>
    /// Numeric identifier of the language.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name of the language (code).
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public required String ShortName { get; set; }

    /// <summary>
    /// Language name in French.
    /// </summary>
    [JsonPropertyName("nom_fr")]
    public required String NameFr { get; set; }

    /// <summary>
    /// Language name in German.
    /// </summary>
    [JsonPropertyName("nom_de")]
    public required String NameDe { get; set; }

    /// <summary>
    /// Language name in English.
    /// </summary>
    [JsonPropertyName("nom_en")]
    public required String NameEn { get; set; }

    /// <summary>
    /// Language name in Spanish.
    /// </summary>
    [JsonPropertyName("nom_es")]
    public required String NameEs { get; set; }

    /// <summary>
    /// Language name in Italian.
    /// </summary>
    [JsonPropertyName("nom_it")]
    public required String NameIt { get; set; }

    /// <summary>
    /// Language name in Portuguese.
    /// </summary>
    [JsonPropertyName("nom_pt")]
    public required String NamePt { get; set; }

    /// <summary>
    /// Identifier of the parent language (0 if it’s a top-level language).
    /// </summary>
    [JsonPropertyName("parent")]
    public Int32 ParentId { get; set; }

    /// <summary>
    /// Media files associated with the language (e.g., icons, backgrounds).
    /// </summary>
    [JsonPropertyName("medias")]
    public Media? Medias { get; set; }
}
