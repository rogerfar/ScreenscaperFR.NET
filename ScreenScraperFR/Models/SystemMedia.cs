﻿using System.Text.Json.Serialization;

namespace ScreenScraperFR;

internal class SystemMediaResponse
{
    [JsonPropertyName("medias")]
    public Dictionary<Int32, SystemMedia> Media { get; set; } = new();
}

public class SystemMedia
{
    /// <summary>
    /// Numeric ID of the media.
    /// </summary>
    [JsonPropertyName("id")]
    public Int32 Id { get; set; }

    /// <summary>
    /// Short name of the media.
    /// </summary>
    [JsonPropertyName("nomcourt")]
    public required String ShortName { get; set; }

    /// <summary>
    /// Long name of the media.
    /// </summary>
    [JsonPropertyName("nom")]
    public required String Name { get; set; }

    /// <summary>
    /// Media category (e.g., Bezels, Logos).
    /// </summary>
    [JsonPropertyName("categorie")]
    public required String Category { get; set; }

    /// <summary>
    /// Pipe-separated list of system type IDs where the media is used.
    /// </summary>
    [JsonPropertyName("plateformtypes")]
    public required String PlatformTypes { get; set; }

    /// <summary>
    /// Pipe-separated list of platform IDs where the media is used.
    /// </summary>
    [JsonPropertyName("plateforms")]
    public required String Platforms { get; set; }

    /// <summary>
    /// Type of media (e.g., image, vectoriel, video, zip).
    /// </summary>
    [JsonPropertyName("type")]
    public required String Type { get; set; }

    /// <summary>
    /// Primary file format (e.g., png, svg, mp4).
    /// </summary>
    [JsonPropertyName("fileformat")]
    public required String FileFormat { get; set; }

    /// <summary>
    /// Secondary file format (e.g., png, svg, mp4).
    /// </summary>
    [JsonPropertyName("fileformat2")]
    public required String FileFormat2 { get; set; }

    /// <summary>
    /// Indicates if media is auto-generated.
    /// </summary>
    [JsonPropertyName("autogen")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsAutoGenerated { get; set; }

    /// <summary>
    /// Indicates if the media supports multiple regions.
    /// </summary>
    [JsonPropertyName("multiregions")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsMultiRegion { get; set; }

    /// <summary>
    /// Indicates if the media supports multiple systems.
    /// </summary>
    [JsonPropertyName("multisupports")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsMultiSupport { get; set; }

    /// <summary>
    /// Indicates if the media supports multiple versions.
    /// </summary>
    [JsonPropertyName("multiversions")]
    [JsonConverter(typeof(JsonBooleanConverter))]
    public Boolean IsMultiVersion { get; set; }

    /// <summary>
    /// Extra information text or metadata related to the media.
    /// </summary>
    [JsonPropertyName("extrainfostxt")]
    public String? ExtraInfoText { get; set; }
}
