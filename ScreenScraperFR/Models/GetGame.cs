using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class GetGameResponse
{
    [JsonPropertyName("jeu")]
    public GetGame? Game { get; set; }
}

/// <summary>
/// Represents detailed information about a game returned from the ScreenScraper API.
/// </summary>
public class GetGame
{
    /// <summary>
    /// Unique identifier for the game.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// List of gameplay actions and control mappings.
    /// </summary>
    [JsonPropertyName("actions")]
    public List<GetGameAction> Actions { get; set; } = [];

    /// <summary>
    /// List of game classifications (e.g. ESRB, PEGI).
    /// </summary>
    [JsonPropertyName("classifications")]
    public List<GetGameClassification> Classifications { get; set; } = [];

    /// <summary>
    /// ID of the parent game if this game is a clone.
    /// </summary>
    [JsonPropertyName("cloneof")]
    public Int32? CloneOfId { get; set; }

    /// <summary>
    /// List of release dates per region.
    /// </summary>
    [JsonPropertyName("dates")]
    public List<GetGameReleaseDate> ReleaseDates { get; set; } = [];

    /// <summary>
    /// Information about the game developer.
    /// </summary>
    [JsonPropertyName("developpeur")]
    public GetGameLink? Developer { get; set; }

    /// <summary>
    /// Information about the game publisher.
    /// </summary>
    [JsonPropertyName("editeur")]
    public GetGameLink? Publisher { get; set; }

    /// <summary>
    /// List of game families (e.g. Sonic series).
    /// </summary>
    [JsonPropertyName("familles")]
    public List<GetGameSerie> Series { get; set; } = [];

    /// <summary>
    /// List of game genres (e.g. Action, RPG).
    /// </summary>
    [JsonPropertyName("genres")]
    public List<GetGameSerie> Genres { get; set; } = [];

    /// <summary>
    /// Game modes (e.g. singleplayer, multiplayer).
    /// </summary>
    [JsonPropertyName("modes")]
    public List<GetGameSerie>? Modes { get; set; }

    /// <summary>
    /// Player count information.
    /// </summary>
    [JsonPropertyName("joueurs")]
    public GetGameText? PlayCounts { get; set; }

    /// <summary>
    /// Associated media files like screenshots, videos, etc.
    /// </summary>
    [JsonPropertyName("medias")]
    public List<GetGameMedia>? Media { get; set; }

    /// <summary>
    /// Localized game names per region.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<GetGameName>? Names { get; set; }

    /// <summary>
    /// Score or rating out of 20.
    /// </summary>
    [JsonPropertyName("note")]
    public GetGameText? Note { get; set; }

    /// <summary>
    /// Indicates if this is not a real game (e.g. demo, app).
    /// </summary>
    [JsonPropertyName("notgame")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsNotAGame { get; set; }

    /// <summary>
    /// Primary ROM information for the game.
    /// </summary>
    [JsonPropertyName("rom")]
    public required GetGameRom Rom { get; set; }

    /// <summary>
    /// Unique identifier for the primary ROM.
    /// </summary>
    [JsonPropertyName("romid")]
    public Int32 RomId { get; set; }

    /// <summary>
    /// List of all ROMs associated with the game.
    /// </summary>
    [JsonPropertyName("roms")]
    public List<GetGameRomElement> Roms { get; set; } = [];

    /// <summary>
    /// Screen rotation (useful for arcade systems).
    /// </summary>
    [JsonPropertyName("rotation")]
    public Int32 Rotation { get; set; }

    /// <summary>
    /// Localized synopsis/descriptions of the game.
    /// </summary>
    [JsonPropertyName("synopsis")]
    public List<GetGameLocalizedText> Synopsis { get; set; } = [];

    /// <summary>
    /// System/platform information (e.g. NES, PS1).
    /// </summary>
    [JsonPropertyName("systeme")]
    public GetGameLink? System { get; set; }

    /// <summary>
    /// Indicates if the game is included in ScreenScraper’s staff top picks.
    /// </summary>
    [JsonPropertyName("topstaff")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean TopStaffSelection { get; set; }
}

/// <summary>
/// Represents a gameplay action, such as jump, shoot, etc.
/// </summary>
public class GetGameAction
{
    [JsonPropertyName("controle")]
    public List<GetGameControl> Controls { get; set; } = [];

    [JsonPropertyName("id")]
    public Int32 Id { get; set; }
}

public class GetGameControl
{
    /// <summary>
    /// Language code (e.g., fr, en).
    /// </summary>
    [JsonPropertyName("langue")]
    public required String LanguageCode { get; set; }

    /// <summary>
    /// Recalbox-specific version of the action text.
    /// </summary>
    [JsonPropertyName("recalboxtext")]
    public required String Recalboxtext { get; set; }

    /// <summary>
    /// Localized text describing the control/action.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a classification label for the game (e.g. ESRB rating).
/// </summary>
public class GetGameClassification
{
    /// <summary>
    /// Classification text (e.g. "Mature", "Everyone").
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }

    /// <summary>
    /// Type or name of the classification system (e.g. "ESRB", "PEGI").
    /// </summary>
    [JsonPropertyName("type")]
    public required String Type { get; set; }
}

/// <summary>
/// Represents a date value related to the game (typically release date by region).
/// </summary>
public class GetGameReleaseDate
{
    /// <summary>
    /// The region associated with the date (e.g. "europe", "usa").
    /// </summary>
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    /// <summary>
    /// The date text (can be partial, e.g. year only).
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents the localized name of a game.
/// </summary>
public class GetGameName
{
    /// <summary>
    /// The region associated with the date (e.g. "europe", "usa").
    /// </summary>
    [JsonPropertyName("region")]
    public required String Region { get; set; }

    /// <summary>
    /// The name or title of the game for this region.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a link to another item (e.g. developer, publisher, system).
/// </summary>
public class GetGameLink
{
    /// <summary>
    /// The ID of the linked item.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// The name or title of the linked item.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a family, genre, or mode grouping of games.
/// </summary>
public class GetGameSerie
{
    /// <summary>
    /// Unique identifier for the family or genre.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name identifier for the group (e.g., "rpg", "action").
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public required String ShortName { get; set; }

    /// <summary>
    /// Localized names per language.
    /// </summary>
    [JsonPropertyName("noms")]
    public List<GetGameLocalizedText> Names { get; set; } = [];

    /// <summary>
    /// Parent group identifier (used for hierarchical genres/families).
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32 ParentId { get; set; }

    /// <summary>
    /// Whether this is the primary family/genre.
    /// </summary>
    [JsonPropertyName("principale")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean Principale { get; set; }
}

/// <summary>
/// Represents a localized text.
/// </summary>
public class GetGameLocalizedText
{
    /// <summary>
    /// The language code (e.g., "fr", "en").
    /// </summary>
    [JsonPropertyName("langue")]
    public required String LanguageCode { get; set; }

    /// <summary>
    /// The translated or localized text.
    /// </summary>
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a simple text value.
/// </summary>
public class GetGameText
{
    [JsonPropertyName("text")]
    public required String Text { get; set; }
}

/// <summary>
/// Represents a media file associated with a game (e.g., screenshot, video, box art).
/// </summary>
public class GetGameMedia
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

/// <summary>
/// Represents detailed information about a ROM associated with a game.
/// </summary>
public class GetGameRom
{
    /// <summary>
    /// Unique identifier of the ROM in the database.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Indicates if this is an alternative version of the ROM.
    /// </summary>
    [JsonPropertyName("alt")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsAlternative { get; set; }

    /// <summary>
    /// Indicates if this is considered the best version.
    /// </summary>
    [JsonPropertyName("best")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBestVersion { get; set; }

    /// <summary>
    /// Indicates if this is a beta version.
    /// </summary>
    [JsonPropertyName("beta")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBeta { get; set; }

    /// <summary>
    /// Indicates if this is a demo version.
    /// </summary>
    [JsonPropertyName("demo")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsDemo { get; set; }

    /// <summary>
    /// Indicates if this ROM is a hack or modified version.
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
    /// Indicates if this ROM is a prototype.
    /// </summary>
    [JsonPropertyName("proto")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsProtoType { get; set; }

    /// <summary>
    /// Regional availability of the ROM.
    /// </summary>
    [JsonPropertyName("regions")]
    public required GetGameRegions Regions { get; set; }

    /// <summary>
    /// ID of the parent ROM if this is a clone.
    /// </summary>
    [JsonPropertyName("romcloneof")]
    public Int32? CloneOf { get; set; }

    /// <summary>
    /// CRC32 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("romcrc")]
    public required String RomCrc { get; set; }

    /// <summary>
    /// Filename of the ROM (or folder name).
    /// </summary>
    [JsonPropertyName("romfilename")]
    public required String RomFilename { get; set; }

    /// <summary>
    /// MD5 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("rommd5")]
    public required String RomMd5 { get; set; }

    /// <summary>
    /// Support number (e.g., disk 1, CD 2, etc.).
    /// </summary>
    [JsonPropertyName("romnumsupport")]
    public Int32 RomNumberSupport { get; set; }

    /// <summary>
    /// Comma-separated list of region codes (e.g. "fr,us,es").
    /// </summary>
    [JsonPropertyName("romregions")]
    public required String Romregions { get; set; }

    /// <summary>
    /// SHA1 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("romsha1")]
    public required String RomSha1 { get; set; }

    /// <summary>
    /// Size of the ROM file or folder in bytes.
    /// </summary>
    [JsonPropertyName("romsize")]
    public Int32 RomSize { get; set; }

    /// <summary>
    /// Type of physical or digital support (e.g. "cartridge", "iso").
    /// </summary>
    [JsonPropertyName("romsupporttype")]
    public required String RomSupportType { get; set; }

    /// <summary>
    /// Total number of supports (e.g. 2 = 2 CDs or 2 diskettes).
    /// </summary>
    [JsonPropertyName("romtotalsupport")]
    public Int32 RomTotalSupports { get; set; }

    /// <summary>
    /// ROM type (e.g. "rom", "iso", "folder").
    /// </summary>
    [JsonPropertyName("romtype")]
    public required String RomType { get; set; }

    /// <summary>
    /// Indicates if this ROM is a translated version (1 = yes, 0 = no).
    /// </summary>
    [JsonPropertyName("trad")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsTranslated { get; set; }

    /// <summary>
    /// Indicates if this is an unofficial release (1 = yes, 0 = no).
    /// </summary>
    [JsonPropertyName("unl")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsUnofficialReleas { get; set; }
}

/// <summary>
/// Represents the regional availability or labels for a ROM or game.
/// </summary>
public class GetGameRegions
{
    /// <summary>
    /// List of German region names or labels.
    /// </summary>
    [JsonPropertyName("regions_de")]
    public List<String> RegionsDe { get; set; } = [];

    /// <summary>
    /// List of English region names or labels.
    /// </summary>
    [JsonPropertyName("regions_en")]
    public List<String> RegionsEn { get; set; } = [];

    /// <summary>
    /// List of Spanish region names or labels.
    /// </summary>
    [JsonPropertyName("regions_es")]
    public List<String> RegionsEs { get; set; } = [];

    /// <summary>
    /// List of French region names or labels.
    /// </summary>
    [JsonPropertyName("regions_fr")]
    public List<String> RegionsFr { get; set; } = [];

    /// <summary>
    /// List of region identifiers (numeric IDs).
    /// </summary>
    [JsonPropertyName("regions_id")]
    public List<Int32> RegionsId { get; set; } = [];

    /// <summary>
    /// List of Portuguese region names or labels.
    /// </summary>
    [JsonPropertyName("regions_pt")]
    public List<String> RegionsPt { get; set; } = [];

    /// <summary>
    /// List of short region names (e.g., "us", "jp").
    /// </summary>
    [JsonPropertyName("regions_shortname")]
    public List<String> RegionsShortNames { get; set; } = [];

    /// <summary>
    /// List of Italian region names or labels.
    /// </summary>
    [JsonPropertyName("regions_it")]
    public List<String> RegionsIt { get; set; } = [];
}

/// <summary>
/// Represents an individual ROM entry associated with a game. 
/// Useful for multi-disc games or games with multiple versions.
/// </summary>
public class GetGameRomElement
{
    /// <summary>
    /// Indicates if this is an alternative version of the ROM.
    /// </summary>
    [JsonPropertyName("alt")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsAlternative { get; set; }

    /// <summary>
    /// Indicates if this is considered the best version.
    /// </summary>
    [JsonPropertyName("best")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBestVersion { get; set; }

    /// <summary>
    /// Indicates if this is a beta version.
    /// </summary>
    [JsonPropertyName("beta")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsBeta { get; set; }

    /// <summary>
    /// Indicates if this is a demo version.
    /// </summary>
    [JsonPropertyName("demo")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsDemo { get; set; }

    /// <summary>
    /// Indicates if this ROM is a hack or modified version.
    /// </summary>
    [JsonPropertyName("hack")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsHack { get; set; }

    /// <summary>
    /// Unique identifier of the ROM in the database.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Indicates if this ROM supports Netplay.
    /// </summary>
    [JsonPropertyName("netplay")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsNetplaySupported { get; set; }

    /// <summary>
    /// Indicates if this ROM is a prototype.
    /// </summary>
    [JsonPropertyName("proto")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsProtoType { get; set; }

    /// <summary>
    /// Regional availability of the ROM.
    /// </summary>
    [JsonPropertyName("regions")]
    public GetGameRegions? Regions { get; set; }

    /// <summary>
    /// ID of the parent ROM if this is a clone.
    /// </summary>
    [JsonPropertyName("romcloneof")]
    public Int32? RomCloneOf { get; set; }

    /// <summary>
    /// CRC32 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("romcrc")]
    public required String RomCrc { get; set; }

    /// <summary>
    /// Filename of the ROM (or folder name).
    /// </summary>
    [JsonPropertyName("romfilename")]
    public required String RomFilename { get; set; }

    /// <summary>
    /// MD5 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("rommd5")]
    public required String RomMd5 { get; set; }

    /// <summary>
    /// Support number (e.g., disk 1, CD 2, etc.).
    /// </summary>
    [JsonPropertyName("romnumsupport")]
    public Int32 RomNumberSupport { get; set; }

    /// <summary>
    /// SHA1 checksum of the ROM.
    /// </summary>
    [JsonPropertyName("romsha1")]
    public required String RomSha1 { get; set; }

    /// <summary>
    /// Size of the ROM file or folder in bytes.
    /// </summary>
    [JsonPropertyName("romsize")]
    public Int32 RomSize { get; set; }

    /// <summary>
    /// Type of physical or digital support (e.g. "cartridge", "iso").
    /// </summary>
    [JsonPropertyName("romtotalsupport")]
    public Int32 RomTotalSupport { get; set; }

    /// <summary>
    /// Indicates if this is a translated ROM.
    /// </summary>
    [JsonPropertyName("trad")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsTranslated { get; set; }

    /// <summary>
    /// Indicates if this is an unofficial release.
    /// </summary>
    [JsonPropertyName("unl")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsUnofficialRelease { get; set; }

    /// <summary>
    /// Language metadata associated with this ROM.
    /// </summary>
    [JsonPropertyName("langues")]
    public GetGameLangues? Langues { get; set; }
}

/// <summary>
/// Represents the available languages for a ROM or game.
/// </summary>
public class GetGameLangues
{
    /// <summary>
    /// List of available German languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_de")]
    public List<String> De { get; set; } = [];

    /// <summary>
    /// List of available English languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_en")]
    public List<String> En { get; set; } = [];

    /// <summary>
    /// List of available Spanish languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_es")]
    public List<String> Es { get; set; } = [];

    /// <summary>
    /// List of available French languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_fr")]
    public List<String> Fr { get; set; } = [];

    /// <summary>
    /// List of internal numeric IDs for each language.
    /// </summary>
    [JsonPropertyName("langues_id")]
    public List<Int32> Id { get; set; } = [];
    
    /// <summary>
    /// List of available Italian languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_it")]
    public List<String> It { get; set; } = [];

    /// <summary>
    /// List of available Portuguese languages (labels or full names).
    /// </summary>
    [JsonPropertyName("langues_pt")]
    public List<String> Pt { get; set; } = [];

    /// <summary>
    /// List of short names (e.g., ISO codes) for available languages.
    /// </summary>
    [JsonPropertyName("langues_shortname")]
    public List<String> ShortName { get; set; } = [];
}
