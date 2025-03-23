using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Media
{
    /// <summary>
    /// Download URL of the monochrome pictogram.
    /// </summary>
    [JsonPropertyName("media_pictomonochrome")]
    public String? PictogramMonochrome { get; set; }

    /// <summary>
    /// Download URL of the colored pictogram.
    /// </summary>
    [JsonPropertyName("media_pictocouleur")]
    public String? PictogramColor { get; set; }

    /// <summary>
    /// Download URL of the background image.
    /// </summary>
    [JsonPropertyName("media_background")]
    public String? Background { get; set; }
}
