using System.Text.Json.Serialization;
using System.Text.Json;

public class JsonEmptyArrayConverter<T> : JsonConverter<List<T>>
{
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException($"Expected StartArray token, got {reader.TokenType}");
        }

        var list = new List<T>();
        
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return list;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                try
                {
                    // Save the current state and get the full JSON being processed
                    using var jsonDoc = JsonDocument.ParseValue(ref reader);
                    var jsonString = jsonDoc.RootElement.GetRawText();

                    // If it's an empty object, skip it
                    if (!jsonDoc.RootElement.EnumerateObject().Any())
                    {
                        continue;
                    }

                    try
                    {
                        var item = JsonSerializer.Deserialize<T>(jsonString, options);
                        if (item != null)
                        {
                            list.Add(item);
                        }
                    }
                    catch (JsonException ex)
                    {
                        throw new JsonException(
                            $"Failed to deserialize type {typeof(T).Name}. " +
                            $"JSON being deserialized: {jsonString}", ex);
                    }
                }
                catch (JsonException ex)
                {
                    throw new JsonException(
                        $"Error processing array element for type {typeof(T).Name}. " +
                        $"Current token: {reader.TokenType}. " +
                        $"Current depth: {reader.CurrentDepth}. " +
                        $"Position: {reader.BytesConsumed}", ex);
                }
            }
        }

        return list;
    }

    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}