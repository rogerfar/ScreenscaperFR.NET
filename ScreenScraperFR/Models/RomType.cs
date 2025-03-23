using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal class RomTypesResponse
{
    [JsonPropertyName("romtypes")]
    public List<String> RomTypes { get; set; } = [];
}
