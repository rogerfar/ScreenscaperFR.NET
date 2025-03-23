using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScreenScraperFR;

internal class JsonBooleanConverter : JsonConverter<Boolean>
{
    public override Boolean Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.String => reader.GetString() switch
            {
                null => false,
                "" => false,
                "0" => false,
                "1" => true,
                "true" => true,
                "false" => false,
                _ => throw new JsonException()
            },
            JsonTokenType.Null => false,
            _ => throw new JsonException($"Cannot convert {reader.GetString()} to Boolean")
        };
    }

    public override void Write(Utf8JsonWriter writer, Boolean value, JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }
}