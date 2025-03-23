using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR.Models;

/// <summary>
/// Response containing a list of games returned by a search.
/// </summary>
internal class SearchGamesResponse
{
    [JsonPropertyName("jeux")]
    public List<SearchGame> Games { get; set; } = [];
}

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class SearchGame
{
    /// <summary>
    /// Game ID (numeric identifier).
    /// </summary>
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    /// <summary>
    /// List of names for the game, including regional variants.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<SearchGameReleaseDate> ReleaseDates { get; set; } = [];

    /// <summary>
    /// System on which the game runs.
    /// </summary>
    [JsonPropertyName("systeme")]
    public SearchGameSystem System { get; set; } = new();

    /// <summary>
    /// Publisher of the game.
    /// </summary>
    [JsonPropertyName("editeur")]
    public SearchGameText? Editeur { get; set; }

    /// <summary>
    /// Developer of the game.
    /// </summary>
    [JsonPropertyName("developpeur")]
    public SearchGameText? Developer { get; set; }

    /// <summary>
    /// Number of players.
    /// </summary>
    [JsonPropertyName("joueurs")]
    public SearchGameTextNode? GameTextNode { get; set; }

    /// <summary>
    /// Game rating out of 20.
    /// </summary>
    [JsonPropertyName("note")]
    public SearchGameTextNode? Note { get; set; }

    /// <summary>
    /// Whether the game is included in ScreenScraper's TOP Staff selection.
    /// </summary>
    [JsonPropertyName("topstaff")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean TopStaffSelection { get; set; }

    /// <summary>
    /// Screen rotation for the game (used mainly for arcade).
    /// </summary>
    [JsonPropertyName("rotation")]

    public Int32 Rotation { get; set; }

    /// <summary>
    /// Control configuration (numeric identifier).
    /// </summary>
    [JsonPropertyName("controles")]

    public Int32 Controles { get; set; }

    /// <summary>
    /// Number of colors used in the game (for arcade).
    /// </summary>
    [JsonPropertyName("couleurs")]

    public Int32 Colors { get; set; }

    /// <summary>
    /// Game synopsis in different languages.
    /// </summary>
    [JsonPropertyName("synopsis")]
    public List<SearchGameLocalizedText> Synopsis { get; set; } = [];

    /// <summary>
    /// Classification/rating organizations (e.g., ESRB, PEGI).
    /// </summary>
    [JsonPropertyName("classifications")]
    public List<Classification> Classifications { get; set; } = [];

    /// <summary>
    /// Release dates by region.
    /// </summary>
    [JsonPropertyName("dates")]
    public List<SearchGameReleaseDate> Dates { get; set; } = [];

    /// <summary>
    /// List of genres for the game.
    /// </summary>
    [JsonPropertyName("genres")]
    public List<SearchGameRelation> Genres { get; set; } = [];

    /// <summary>
    /// List of game modes (e.g., single-player, multiplayer).
    /// </summary>
    [JsonPropertyName("modes")]
    public List<SearchGameRelation> Modes { get; set; } = [];

    /// <summary>
    /// Families or franchises the game belongs to (e.g., "Mario", "Zelda").
    /// </summary>
    [JsonPropertyName("familles")]
    public List<SearchGameRelation> Families { get; set; } = [];

    /// <summary>
    /// Media associated with the game (images, videos, manuals, etc.).
    /// </summary>
    [JsonPropertyName("medias")]
    public List<Media> Medias { get; set; } = [];
}

/// <summary>
/// Game classification (e.g., PEGI 12, ESRB Teen).
/// </summary>
public class SearchGameClassification
{
    [JsonPropertyName("type")]
    public String Type { get; set; } = "";

    [JsonPropertyName("text")]
    public String Text { get; set; } = "";
}

/// <summary>
/// Release date info by region.
/// </summary>
public class SearchGameReleaseDate
{
    [JsonPropertyName("region")]
    public String Region { get; set; } = "";

    [JsonPropertyName("text")]
    public String Text { get; set; } = "";
}

/// <summary>
/// Basic representation for publisher or developer.
/// </summary>
public class SearchGameText
{
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; } = "";
}

/// <summary>
/// Represents a genre, mode, or family.
/// </summary>
public class SearchGameRelation
{
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    /// <summary>
    /// Short name (e.g., internal ID or abbreviation).
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public String ShortName { get; set; } = "";

    /// <summary>
    /// Indicates whether this is the primary item (1 = primary, 0 = not).
    /// </summary>
    [JsonPropertyName("principale")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsPrimary { get; set; }

    /// <summary>
    /// ID of the parent category.
    /// </summary>
    [JsonPropertyName("parentid")]

    public Int32 Parentid { get; set; }

    /// <summary>
    /// Names of the item in multiple languages.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<SearchGameLocalizedText> Names { get; set; } = [];
}

/// <summary>
/// Text content localized by language (used for names, descriptions, etc.).
/// </summary>
public class SearchGameLocalizedText
{
    /// <summary>
    /// Language code (e.g., "fr", "en").
    /// </summary>
    [JsonPropertyName("langue")]
    public String Langue { get; set; } = "";

    /// <summary>
    /// Translated or localized text.
    /// </summary>
    [JsonPropertyName("text")]
    public String Text { get; set; } = "";
}

/// <summary>
/// Textual information, often used for number of players or ratings.
/// </summary>
public class SearchGameTextNode
{
    [JsonPropertyName("text")]
    public String Text { get; set; } = "";
}

/// <summary>
/// System/platform information for a game (e.g., SNES, PlayStation).
/// </summary>
public class SearchGameSystem
{
    [JsonPropertyName("id")]

    public Int32 Id { get; set; }

    [JsonPropertyName("text")]
    public String Text { get; set; } = "";

    /// <summary>
    /// Parent system ID (if part of a hierarchy).
    /// </summary>
    [JsonPropertyName("parentid")]

    public Int32? Parentid { get; set; }
}
