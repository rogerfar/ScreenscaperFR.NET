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
    public List<SearchGameName> Names { get; set; } = [];

    /// <summary>
    /// System on which the game runs.
    /// </summary>
    [JsonPropertyName("systeme")]
    public required SearchGameSystem System { get; set; }

    /// <summary>
    /// Publisher of the game.
    /// </summary>
    [JsonPropertyName("editeur")]
    public required SearchGameText Publisher { get; set; }

    /// <summary>
    /// Developer of the game.
    /// </summary>
    [JsonPropertyName("developpeur")]
    public required SearchGameText Developer { get; set; }

    /// <summary>
    /// Number of players.
    /// </summary>
    [JsonPropertyName("joueurs")]
    public required SearchGameTextNode PlayerCounts { get; set; }

    /// <summary>
    /// Game rating out of 20.
    /// </summary>
    [JsonPropertyName("note")]
    public required SearchGameTextNode Rating { get; set; }

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
    public List<SearchGameClassification> Classifications { get; set; } = [];

    /// <summary>
    /// Release dates by region.
    /// </summary>
    [JsonPropertyName("dates")]
    public List<SearchGameReleaseDate> ReleaseDates { get; set; } = [];

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
    /// Series or franchises the game belongs to (e.g., "Mario", "Zelda").
    /// </summary>
    [JsonPropertyName("familles")]
    public List<SearchGameRelation> Series { get; set; } = [];

    /// <summary>
    /// Media associated with the game (images, videos, manuals, etc.).
    /// </summary>
    [JsonPropertyName("medias")]
    public List<SearchGameMedia> Media { get; set; } = [];
}

/// <summary>
/// Game classification (e.g., PEGI 12, ESRB Teen).
/// </summary>
public class SearchGameClassification
{
    [JsonPropertyName("type")]
    public required String Type { get; set; }

    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Game name by region.
/// </summary>
public class SearchGameName
{
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Release date info by region.
/// </summary>
public class SearchGameReleaseDate
{
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Basic representation for publisher or developer.
/// </summary>
public class SearchGameText
{
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    [JsonPropertyName("text")]
    public required String Text { get; set; }
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
    public required String ShortName { get; set; }

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
    public Int32? Parentid { get; set; }

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
    public required String Language { get; set; }

    /// <summary>
    /// Translated or localized text.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Textual information, often used for number of players or ratings.
/// </summary>
public class SearchGameTextNode
{
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// System/platform information for a game (e.g., SNES, PlayStation).
/// </summary>
public class SearchGameSystem
{
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    [JsonPropertyName("text")]
    public required String Text { get; set; }

    /// <summary>
    /// Parent system ID (if part of a hierarchy).
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32? Parentid { get; set; }
}

/// <summary>
/// Represents a media file associated with a game (e.g., screenshot, video, box art).
/// </summary>
public class SearchGameMedia
{
    /// <summary>
    /// Unique identifier of the media 
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// CRC32 hash of the media file.
    /// </summary>
    [JsonPropertyName("crc")]
    public required String Crc { get; set; }

    /// <summary>
    /// Format of the media file (e.g., png, jpg, mp4).
    /// </summary>
    [JsonPropertyName("format")]
    public required String Format { get; set; }

    /// <summary>
    /// MD5 hash of the media file.
    /// </summary>
    [JsonPropertyName("md5")]
    public required String Md5 { get; set; }

    /// <summary>
    /// Parent type/category of the media.
    /// </summary>
    [JsonPropertyName("parent")]
    public required String Parent { get; set; }

    /// <summary>
    /// Region this media is associated with (optional).
    /// </summary>
    [JsonPropertyName("region")]
    public String? Region { get; set; }

    /// <summary>
    /// SHA1 hash of the media file.
    /// </summary>
    [JsonPropertyName("sha1")]
    public required String Sha1 { get; set; }

    /// <summary>
    /// Size of the media file in bytes.
    /// </summary>
    [JsonPropertyName("size")]
    public Int32 Size { get; set; }

    /// <summary>
    /// Type of the media (e.g., "screenshot", "video", "boxart").
    /// </summary>
    [JsonPropertyName("type")]
    public required String Type { get; set; }

    /// <summary>
    /// URL to download the media file.
    /// </summary>
    [JsonPropertyName("url")]
    public required String Url { get; set; }

    /// <summary>
    /// Support type identifier (e.g. physical medium indicator).
    /// </summary>
    [JsonPropertyName("support")]
    public Int32? Support { get; set; }

    /// <summary>
    /// Vertical position for displaying the media (optional).
    /// </summary>
    [JsonPropertyName("posh")]
    public Int32? PosH { get; set; }

    /// <summary>
    /// Width value for the media display position (optional).
    /// </summary>
    [JsonPropertyName("posw")]
    public Int32? PosW { get; set; }

    /// <summary>
    /// Horizontal position X for displaying the media (optional).
    /// </summary>
    [JsonPropertyName("posx")]
    public Int32? PosX { get; set; }

    /// <summary>
    /// Vertical position Y for displaying the media (optional).
    /// </summary>
    [JsonPropertyName("posy")]
    public Int32? PosY { get; set; }

    /// <summary>
    /// Additional categorization information, if the media belongs to a subcategory.
    /// </summary>
    [JsonPropertyName("subparent")]
    public String? SubParent { get; set; }
}