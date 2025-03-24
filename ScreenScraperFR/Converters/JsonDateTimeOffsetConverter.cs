using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScreenScraperFR;

internal class JsonDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    // GMT+1 TimeSpan offset
    private static readonly TimeSpan FranceOffset = TimeSpan.FromHours(1);

    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();

        if (stringValue is not null)
        {
            if (String.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }

            // Parse the date string without timezone info
            var dateTime = DateTime.ParseExact(stringValue, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            
            // Create a new DateTimeOffset with the France timezone offset
            return new DateTimeOffset(dateTime, FranceOffset);
        }
        
        throw new JsonException($"Cannot convert {stringValue} to DateTimeOffset");
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        var date = value.Value.ToUniversalTime();

        writer.WriteStringValue($"{date:yyyy-MM-dd}T{date:HH:mm:ss}Z");
    }
}
