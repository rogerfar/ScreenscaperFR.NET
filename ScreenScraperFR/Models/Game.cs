using System.Text.Json.Serialization;

namespace ScreenScraperFR;

/// <summary>
/// Represents a full ScreenScraper game entry, including metadata, system, genres, media, and more.
/// </summary>
public class Game
{
    /// <summary>
    /// Numeric ID of the game.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Localized names of the game by region.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<GameLocalizedName> Names { get; set; } = [];

    /// <summary>
    /// Platform or system the game belongs to.
    /// </summary>
    [JsonPropertyName("systeme")]
    public required GameSystem System { get; set; }

    /// <summary>
    /// Publisher of the game.
    /// </summary>
    [JsonPropertyName("editeur")]
    public GamePublisher? Publisher { get; set; }

    /// <summary>
    /// Developer of the game.
    /// </summary>
    [JsonPropertyName("developpeur")]
    public GameDeveloper? Developer { get; set; }

    /// <summary>
    /// Number of players supported.
    /// </summary>
    [JsonPropertyName("joueurs")]
    public GamePlayerInfo? PlayerCount { get; set; }

    /// <summary>
    /// Rating of the game (out of 20).
    /// </summary>
    [JsonPropertyName("note")]
    public GameRating? Rating { get; set; }

    /// <summary>
    /// Indicates whether the game is included in ScreenScraper's Staff Picks.
    /// </summary>
    [JsonPropertyName("topstaff")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean? IsTopStaffPick { get; set; }

    /// <summary>
    /// Indicates whether the ROM is assigned to a non-game (demo, app, etc.).
    /// </summary>
    [JsonPropertyName("notgame")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean? IsNotAGame { get; set; }

    /// <summary>
    /// ID of the game this one is a clone of (if applicable).
    /// </summary>
    [JsonPropertyName("cloneof")]
    public Int32? CloneOfId { get; set; }

    /// <summary>
    /// Screen rotation (for arcade games).
    /// </summary>
    [JsonPropertyName("rotation")]
    public Int32? Rotation { get; set; }

    /// <summary>
    /// Screen resolution of the game (used primarily for arcade titles).
    /// </summary>
    [JsonPropertyName("resolution")]
    public String? Resolution { get; set; }

    /// <summary>
    /// ID of the game's control configuration.
    /// </summary>
    [JsonPropertyName("controles")]
    public Int32? ControlSchemeId { get; set; }

    /// <summary>
    /// Number of colors used in the game (for arcade).
    /// </summary>
    [JsonPropertyName("couleurs")]
    public Int32? ColorCount { get; set; }

    [JsonPropertyName("sp2kcfg")]
    public String? Sp2kConfig { get; set; }

    /// <summary>
    /// Gameplay actions and control mappings.
    /// </summary>
    [JsonPropertyName("actions")]
    public List<GameAction> Actions { get; set; } = [];

    /// <summary>
    /// Classification labels from rating organizations (PEGI, ESRB, etc.).
    /// </summary>
    [JsonPropertyName("classifications")]
    public List<GameClassification> Classifications { get; set; } = [];

    /// <summary>
    /// Release dates by region.
    /// </summary>
    [JsonPropertyName("dates")]
    public List<GameReleaseDate> ReleaseDates { get; set; } = [];

    /// <summary>
    /// Series or franchise information for the game.
    /// </summary>
    [JsonPropertyName("familles")]
    public List<GameSeries> Series { get; set; } = [];

    /// <summary>
    /// List of genres the game belongs to.
    /// </summary>
    [JsonPropertyName("genres")]
    public List<GameSeries> Genres { get; set; } = [];

    /// <summary>
    /// Game modes (e.g., Single-player, Co-op).
    /// </summary>
    [JsonPropertyName("modes")]
    public List<GameSeries> Modes { get; set; } = [];

    /// <summary>
    /// List of game numbers in a series (e.g., "2" for Sonic 2).
    /// Used for organizing titles within the same franchise.
    /// </summary>
    [JsonPropertyName("numeros")]
    public List<GameSeries> Numbers { get; set; } = [];

    /// <summary>
    /// List of themes associated with the game (e.g., "Fantasy", "Horror").
    /// Represents the emotional or visual setting of the game.
    /// </summary>
    [JsonPropertyName("themes")]
    public List<GameSeries> Themes { get; set; } = [];

    /// <summary>
    /// List of gameplay styles (e.g., "Arcade", "Simulation").
    /// Defines the mechanical feel or approach of the game.
    /// </summary>
    [JsonPropertyName("styles")]
    public List<GameSeries> Styles { get; set; } = [];

    /// <summary>
    /// Localized game synopsis/descriptions.
    /// </summary>
    [JsonPropertyName("synopsis")]
    public List<GameLocalizedText> Synopsis { get; set; } = [];

    /// <summary>
    /// Media files related to the game (screenshots, videos, manuals, etc.).
    /// </summary>
    [JsonPropertyName("medias")]
    public List<GameMedia> Media { get; set; } = [];

    /// <summary>
    /// ID of the main ROM assigned to this game.
    /// </summary>
    [JsonPropertyName("romid")]
    public Int32? RomId { get; set; }

    /// <summary>
    /// Main ROM details if a ROM is associated with this game.
    /// </summary>
    [JsonPropertyName("rom")]
    public GameRom? Rom { get; set; }

    /// <summary>
    /// All known ROMs associated with this game.
    /// </summary>
    [JsonPropertyName("roms")]
    public List<GameRom> Roms { get; set; } = [];
}

/// <summary>
/// Represents a localized name for the game in a specific region.
/// </summary>
public class GameLocalizedName
{
    /// <summary>
    /// Region code (e.g., "fr", "us", "jp").
    /// </summary>
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    /// <summary>
    /// Localized name or title of the game for the specified region.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents the system/platform to which the game belongs (e.g., SNES, PS1).
/// </summary>
public class GameSystem
{
    /// <summary>
    /// Numeric ID of the game system.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Name of the game system.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Name { get; set; }

    /// <summary>
    /// Numeric ID of the parent system, if this is a sub-system.
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32? ParentId { get; set; }
}

/// <summary>
/// Represents the publisher of the game.
/// </summary>
public class GamePublisher
{
    /// <summary>
    /// Numeric ID of the publisher.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Name of the publisher.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Name { get; set; }
}

/// <summary>
/// Represents the developer of the game.
/// </summary>
public class GameDeveloper
{
    /// <summary>
    /// Numeric ID of the developer.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Name of the developer.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Name { get; set; }
}

/// <summary>
/// Represents the number of players supported by the game.
/// </summary>
public class GamePlayerInfo
{
    /// <summary>
    /// Text description of the number of players (e.g., "1-2", "Multiplayer").
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents the rating of the game (out of 20).
/// </summary>
public class GameRating
{
    /// <summary>
    /// Text description of the game's rating (e.g., "18", "15.5").
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents an in-game action (e.g., Jump, Shoot) and its localized control labels.
/// </summary>
public class GameAction
{
    /// <summary>
    /// Numeric ID of the action.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// List of localized control information for this action.
    /// </summary>
    [JsonPropertyName("controle")]
    public List<GameControl> Controls { get; set; } = [];
}

/// <summary>
/// Represents a localized control label and optional Recalbox-specific text for a game action.
/// </summary>
public class GameControl
{
    /// <summary>
    /// Language code for the text (e.g., "fr", "en").
    /// </summary>
    [JsonPropertyName("langue")]
    public required String Language { get; set; }

    /// <summary>
    /// Localized label for the action in the given language.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }

    /// <summary>
    /// Recalbox-standardized control text in the given language.
    /// </summary>
    [JsonPropertyName("recalboxtext")]
    public required String RecalboxText { get; set; }
}

/// <summary>
/// Represents a classification or rating label assigned to the game (e.g., PEGI, ESRB).
/// </summary>
public class GameClassification
{
    /// <summary>
    /// Type or name of the classification organization (e.g., "PEGI", "ESRB").
    /// </summary>
    [JsonPropertyName("type")]
    public required String Type { get; set; }

    /// <summary>
    /// The classification value or label (e.g., "18+", "Teen").
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents the game's release date for a specific region.
/// </summary>
public class GameReleaseDate
{
    /// <summary>
    /// Region name or code (e.g., "france", "usa", "japon").
    /// </summary>
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    /// <summary>
    /// Date text for the release (may be partial, e.g., year only).
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a series, genre, mode, or family grouping for the game.
/// </summary>
public class GameSeries
{
    /// <summary>
    /// Numeric ID of the series/genre/mode/family.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name or code of the item (e.g., internal identifier like "rpg", "action").
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public required String ShortName { get; set; }

    /// <summary>
    /// Whether this item is marked as the primary category (1 = primary, 0 = not).
    /// </summary>
    [JsonPropertyName("principale")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsPrimary { get; set; }

    /// <summary>
    /// ID of the parent item if this belongs to a hierarchy (e.g., subgenre).
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32? ParentId { get; set; }

    /// <summary>
    /// Localized names for the series/genre/mode/family.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<GameLocalizedText> Names { get; set; } = [];
}

/// <summary>
/// Represents a localized piece of text, such as a name, description, or label.
/// </summary>
public class GameLocalizedText
{
    /// <summary>
    /// Language code (e.g., "fr", "en", "es").
    /// </summary>
    [JsonPropertyName("langue")]
    public required String Language { get; set; }

    /// <summary>
    /// The localized or translated text.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a media file associated with the game (e.g., screenshot, video, box art).
/// </summary>
public class GameMedia
{
    /// <summary>
    /// Unique identifier of the media file.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// CRC32 hash of the media file.
    /// </summary>
    [JsonPropertyName("crc")]
    public required String Crc { get; set; }

    /// <summary>
    /// Format of the media (e.g., "png", "jpg", "mp4").
    /// </summary>
    [JsonPropertyName("format")]
    public required String Format { get; set; }

    /// <summary>
    /// MD5 hash of the media file.
    /// </summary>
    [JsonPropertyName("md5")]
    public required String Md5 { get; set; }

    /// <summary>
    /// Parent type or category of the media (e.g., "media_wheels", "media_fanart").
    /// </summary>
    [JsonPropertyName("parent")]
    public required String Parent { get; set; }

    /// <summary>
    /// Region associated with the media (e.g., "fr", "usa").
    /// </summary>
    [JsonPropertyName("region")]
    public String? Region { get; set; }

    /// <summary>
    /// SHA1 hash of the media file.
    /// </summary>
    [JsonPropertyName("sha1")]
    public required String Sha1 { get; set; }

    /// <summary>
    /// File size in bytes.
    /// </summary>
    [JsonPropertyName("size")]
    public Int32? Size { get; set; }

    /// <summary>
    /// Type of media (e.g., "screenshot", "video").
    /// </summary>
    [JsonPropertyName("type")]
    public required String Type { get; set; }

    /// <summary>
    /// URL to download the media file.
    /// </summary>
    [JsonPropertyName("url")]
    public required Uri Url { get; set; }

    /// <summary>
    /// Support index for multi-disc or multi-support media (e.g., CD1, Disk2).
    /// </summary>
    [JsonPropertyName("support")]
    public Int32? Support { get; set; }

    /// <summary>
    /// Vertical position hint for displaying the media.
    /// </summary>
    [JsonPropertyName("posh")]
    public Int32? PosH { get; set; }

    /// <summary>
    /// Width value for layout positioning of the media.
    /// </summary>
    [JsonPropertyName("posw")]
    public Int32? PosW { get; set; }

    /// <summary>
    /// Horizontal position X value for display.
    /// </summary>
    [JsonPropertyName("posx")]
    public Int32? PosX { get; set; }

    /// <summary>
    /// Vertical position Y value for display.
    /// </summary>
    [JsonPropertyName("posy")]
    public Int32? PosY { get; set; }

    /// <summary>
    /// Optional subcategory within the parent (e.g., "carbon", "steel").
    /// </summary>
    [JsonPropertyName("subparent")]
    public String? SubParent { get; set; }

    /// <summary>
    /// Optional version label for the media (e.g., "v1", "alternate").
    /// </summary>
    [JsonPropertyName("version")]
    public String? Version { get; set; }
}

/// <summary>
/// Represents a ROM associated with the game. Used for both the main ROM and additional ROM entries.
/// </summary>
public class GameRom
{
    /// <summary>
    /// Numeric ID of the ROM in the database.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Indicates if this ROM is an alternative version.
    /// </summary>
    [JsonPropertyName("alt")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsAlternative { get; set; }

    /// <summary>
    /// Indicates if this ROM is the best version.
    /// </summary>
    [JsonPropertyName("best")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBestVersion { get; set; }

    /// <summary>
    /// Indicates if this ROM is a beta version.
    /// </summary>
    [JsonPropertyName("beta")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBeta { get; set; }

    /// <summary>
    /// Indicates if this ROM is a demo version.
    /// </summary>
    [JsonPropertyName("demo")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsDemo { get; set; }

    /// <summary>
    /// Indicates if this ROM has been modified (hack).
    /// </summary>
    [JsonPropertyName("hack")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsHack { get; set; }

    /// <summary>
    /// Indicates if this ROM supports Netplay.
    /// </summary>
    [JsonPropertyName("netplay")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean SupportsNetplay { get; set; }

    /// <summary>
    /// Indicates if this ROM is a prototype version.
    /// </summary>
    [JsonPropertyName("proto")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsPrototype { get; set; }

    /// <summary>
    /// Regional metadata associated with the ROM.
    /// </summary>
    [JsonPropertyName("regions")]
    public GameRegions? Regions { get; set; }

    /// <summary>
    /// ID of the parent ROM (if this ROM is a clone).
    /// </summary>
    [JsonPropertyName("romcloneof")]
    public Int32? CloneOf { get; set; }

    /// <summary>
    /// CRC32 checksum of the ROM file.
    /// </summary>
    [JsonPropertyName("romcrc")]
    public required String RomCrc { get; set; }

    /// <summary>
    /// Filename or folder name of the ROM.
    /// </summary>
    [JsonPropertyName("romfilename")]
    public required String RomFilename { get; set; }

    /// <summary>
    /// MD5 hash of the ROM file.
    /// </summary>
    [JsonPropertyName("rommd5")]
    public required String RomMd5 { get; set; }

    /// <summary>
    /// Index number of the support medium (e.g., CD 1).
    /// </summary>
    [JsonPropertyName("romnumsupport")]
    public Int32 MediaPartNumber { get; set; }

    /// <summary>
    /// Comma-separated region codes (e.g., "fr,us,es").
    /// </summary>
    [JsonPropertyName("romregions")]
    public String? RomRegions { get; set; }

    /// <summary>
    /// SHA1 checksum of the ROM file.
    /// </summary>
    [JsonPropertyName("romsha1")]
    public required String RomSha1 { get; set; }

    /// <summary>
    /// Size of the ROM file or folder in bytes.
    /// </summary>
    [JsonPropertyName("romsize")]
    public Int32 RomSize { get; set; }

    /// <summary>
    /// Type of physical or digital support (e.g., cartridge, iso).
    /// </summary>
    [JsonPropertyName("romsupporttype")]
    public String? RomMediaType { get; set; }

    /// <summary>
    /// Total number of support files (e.g., 2 discs).
    /// </summary>
    [JsonPropertyName("romtotalsupport")]
    public Int32 MediaPartCount { get; set; }

    /// <summary>
    /// Type of the ROM (e.g., "rom", "folder", "iso").
    /// </summary>
    [JsonPropertyName("romtype")]
    public String? RomType { get; set; }

    /// <summary>
    /// Indicates if this ROM is a translated version.
    /// </summary>
    [JsonPropertyName("trad")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsTranslated { get; set; }

    /// <summary>
    /// Indicates if this ROM is unofficial.
    /// </summary>
    [JsonPropertyName("unl")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsUnofficial { get; set; }

    /// <summary>
    /// Language metadata associated with the ROM.
    /// </summary>
    [JsonPropertyName("langues")]
    public GameLanguages? Languages { get; set; }
}

/// <summary>
/// Represents the regional metadata associated with a ROM or game.
/// </summary>
public class GameRegions
{
    /// <summary>
    /// List of region identifiers (numeric IDs).
    /// </summary>
    [JsonPropertyName("regions_id")]
    public List<Int32> Ids { get; set; } = [];

    /// <summary>
    /// List of short region names (e.g., "us", "jp").
    /// </summary>
    [JsonPropertyName("regions_shortname")]
    public List<String> ShortNames { get; set; } = [];

    /// <summary>
    /// List of German region names or labels.
    /// </summary>
    [JsonPropertyName("regions_de")]
    public List<String> De { get; set; } = [];

    /// <summary>
    /// List of English region names or labels.
    /// </summary>
    [JsonPropertyName("regions_en")]
    public List<String> En { get; set; } = [];

    /// <summary>
    /// List of Spanish region names or labels.
    /// </summary>
    [JsonPropertyName("regions_es")]
    public List<String> Es { get; set; } = [];

    /// <summary>
    /// List of French region names or labels.
    /// </summary>
    [JsonPropertyName("regions_fr")]
    public List<String> Fr { get; set; } = [];

    /// <summary>
    /// List of Italian region names or labels.
    /// </summary>
    [JsonPropertyName("regions_it")]
    public List<String> It { get; set; } = [];

    /// <summary>
    /// List of Portuguese region names or labels.
    /// </summary>
    [JsonPropertyName("regions_pt")]
    public List<String> Pt { get; set; } = [];
}

/// <summary>
/// Represents the available languages for a ROM or game.
/// </summary>
public class GameLanguages
{
    /// <summary>
    /// List of language identifiers (numeric IDs).
    /// </summary>
    [JsonPropertyName("langues_id")]
    public List<Int32> Ids { get; set; } = [];

    /// <summary>
    /// List of short language codes (e.g., "en", "fr").
    /// </summary>
    [JsonPropertyName("langues_shortname")]
    public List<String> ShortNames { get; set; } = [];

    /// <summary>
    /// List of available German languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_de")]
    public List<String> De { get; set; } = [];

    /// <summary>
    /// List of available English languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_en")]
    public List<String> En { get; set; } = [];

    /// <summary>
    /// List of available Spanish languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_es")]
    public List<String> Es { get; set; } = [];

    /// <summary>
    /// List of available French languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_fr")]
    public List<String> Fr { get; set; } = [];
    
    /// <summary>
    /// List of available Italian languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_it")]
    public List<String> It { get; set; } = [];

    /// <summary>
    /// List of available Portuguese languages (labels or names).
    /// </summary>
    [JsonPropertyName("langues_pt")]
    public List<String> Pt { get; set; } = [];
}
