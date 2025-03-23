using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ScreenScraperFR;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
internal class SupportTypesResponse
{
    [JsonPropertyName("supporttypes")]
    public List<String> SupportTypes { get; set; } = [];
}