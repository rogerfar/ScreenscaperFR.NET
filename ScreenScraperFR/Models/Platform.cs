using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class PlatformsResponse
{
    [JsonPropertyName("systemes")]
    [JsonConverter(typeof(JsonEmptyArrayConverter<Platform>))]
    public List<Platform> Platforms { get; set; } = [];
}

public class Platform
{
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    [JsonPropertyName("noms")]
    public required PlatformNames Names { get; set; }

    /// <summary>
    /// Supported ROM file extensions (across all emulators).
    /// </summary>

    [JsonPropertyName("extensions")]
    public String? Extensions { get; set; }

    /// <summary>
    /// Name of the company that produced the platform.
    /// </summary>
    [JsonPropertyName("compagnie")]
    public String? Company { get; set; }

    /// <summary>
    /// Type of platform (e.g., Arcade, Console, Handheld, etc.).
    /// </summary>
    [JsonPropertyName("type")]
    public String? Type { get; set; }

    /// <summary>
    /// Start year of production.
    /// </summary>

    [JsonPropertyName("datedebut")]
    public String? StartYear { get; set; }

    /// <summary>
    /// End year of production.
    /// </summary>

    [JsonPropertyName("datefin")]
    public String? EndYear { get; set; }

    /// <summary>
    /// Type(s) of ROMs used by the platform.
    /// </summary>
    [JsonPropertyName("romtype")]
    public required String RomType { get; set; }

    /// <summary>
    /// Type(s) of physical media used by the platform (e.g., cartridge, CD).
    /// </summary>
    [JsonPropertyName("supporttype")]
    public required String MediaType { get; set; }

    /// <summary>
    /// Media assets related to the platform (images, videos, bezels, etc.).
    /// </summary>
    [JsonPropertyName("medias")]
    public List<Dictionary<String, String>> Media { get; set; } = [];

    /// <summary>
    /// ID of the parent platform, if applicable.
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32? ParentId { get; set; }
}

/// <summary>
/// Localized and frontend-specific names for a platform.
/// </summary>
public class PlatformNames
{
    /// <summary>
    /// Common names used for the platform.
    /// </summary>
    [JsonPropertyName("noms_commun")]
    public String? Names { get; set; }

    /// <summary>
    /// European name of the platform.
    /// </summary>
    [JsonPropertyName("nom_eu")]
    public required String Eu { get; set; }

    /// <summary>
    /// Name used in HyperSpin frontend.
    /// </summary>
    [JsonPropertyName("nom_hyperspin")]
    public String? Hyperspin { get; set; }

    /// <summary>
    /// Japanese name of the platform.
    /// </summary>
    [JsonPropertyName("nom_jp")]
    public String? Jp { get; set; }

    /// <summary>
    /// Name used in LaunchBox frontend.
    /// </summary>
    [JsonPropertyName("nom_launchbox")]
    public String? Launchbox { get; set; }

    /// <summary>
    /// Name used in Recalbox frontend.
    /// </summary>
    [JsonPropertyName("nom_recalbox")]
    public String? Recalbox { get; set; }

    /// <summary>
    /// Name used in RetroPie frontend.
    /// </summary>
    [JsonPropertyName("nom_retropie")]
    public String? Retropie { get; set; }

    /// <summary>
    /// US name of the platform.
    /// </summary>
    [JsonPropertyName("nom_us")]
    public String? Us { get; set; }
}
