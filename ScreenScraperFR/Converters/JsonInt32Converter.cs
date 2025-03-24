using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScreenScraperFR;

internal class JsonInt32Converter : JsonConverter<Int32?>
{
    public override Int32? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.String:
            {
                var stringValue = reader.GetString();

                if (String.IsNullOrEmpty(stringValue))
                {
                    return null;
                }

                if (Int32.TryParse(stringValue, out var result))
                {
                    return result;
                }

                break;
            }
        }

        throw new JsonException($"Cannot convert {reader.GetString()} to Int32");
    }

    public override void Write(Utf8JsonWriter writer, Int32? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteNumberValue(value.Value);
    }
}
