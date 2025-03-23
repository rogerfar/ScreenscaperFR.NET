using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class SystemsResponse
{
    [JsonPropertyName("systemes")]
    public List<System> Systems { get; set; } = [];
}

public class System
{
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    [JsonPropertyName("noms")]
    public required SystemNames Names { get; set; }

    /// <summary>
    /// Supported ROM file extensions (across all emulators).
    /// </summary>

    [JsonPropertyName("extensions")]
    public String? Extensions { get; set; }

    /// <summary>
    /// Name of the company that produced the system.
    /// </summary>

    [JsonPropertyName("compagnie")]
    public String? Company { get; set; }

    /// <summary>
    /// Type of system (e.g., Arcade, Console, Handheld, etc.).
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
    /// Type(s) of ROMs used by the system.
    /// </summary>
    [JsonPropertyName("romtype")]
    public required String RomType { get; set; }

    /// <summary>
    /// Type(s) of physical media used by the system (e.g., cartridge, CD).
    /// </summary>
    [JsonPropertyName("supporttype")]
    public required String MediaType { get; set; }

    /// <summary>
    /// Media assets related to the system (images, videos, bezels, etc.).
    /// </summary>
    [JsonPropertyName("medias")]
    public List<Dictionary<String, String>> Media { get; set; } = [];

    /// <summary>
    /// ID of the parent system, if applicable.
    /// </summary>
    [JsonPropertyName("parentid")]
    public Int32? ParentId { get; set; }
}

/// <summary>
/// Localized and frontend-specific names for a system.
/// </summary>
public class SystemNames
{
    /// <summary>
    /// European name of the system.
    /// </summary>
    [JsonPropertyName("nom_eu")]
    public required String NameEu { get; set; }

    /// <summary>
    /// US name of the system.
    /// </summary>
    [JsonPropertyName("nom_us")]
    public String? NameUs { get; set; }

    /// <summary>
    /// Name used in Recalbox frontend.
    /// </summary>
    [JsonPropertyName("nom_recalbox")]
    public String? NameRecalbox { get; set; }

    /// <summary>
    /// Name used in RetroPie frontend.
    /// </summary>
    [JsonPropertyName("nom_retropie")]
    public String? NameRetropie { get; set; }

    /// <summary>
    /// Name used in LaunchBox frontend.
    /// </summary>
    [JsonPropertyName("nom_launchbox")]
    public String? NameLaunchbox { get; set; }

    /// <summary>
    /// Name used in HyperSpin frontend.
    /// </summary>
    [JsonPropertyName("nom_hyperspin")]
    public String? NameHyperspin { get; set; }

    /// <summary>
    /// Common names used for the system.
    /// </summary>
    [JsonPropertyName("noms_commun")]
    public String? CommonNames { get; set; }

    /// <summary>
    /// Japanese name of the system.
    /// </summary>
    [JsonPropertyName("nom_jp")]
    public String? NameJp { get; set; }
}
