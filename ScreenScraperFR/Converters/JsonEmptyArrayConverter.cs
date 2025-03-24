using System.Text.Json.Serialization;
using System.Text.Json;

namespace ScreenScraperFR;

public class JsonEmptyArrayConverter<T> : JsonConverter<List<T>>
{
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException("Expected start of array");
        }

        // Read the first token after the start array
        reader.Read();

        // Check if we have the empty object case [{}]
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            var startDepth = reader.CurrentDepth;
            reader.Read(); // Read next token
            
            // If we immediately hit EndObject, it's an empty object
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                reader.Read(); // Read past the end of array
                return new List<T>(); // Return empty list
            }
            
            // If we get here, it's a real object, so we need to rewind
            reader.Skip();
            reader.Skip();
        }

        // If we get here, we have actual game data to deserialize
        return JsonSerializer.Deserialize<List<T>>(ref reader, options) ?? new List<T>();
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}