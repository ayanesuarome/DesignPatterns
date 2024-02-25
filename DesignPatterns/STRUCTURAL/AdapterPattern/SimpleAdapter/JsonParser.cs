using System.Text.Json;

namespace AdapterPattern.SimpleAdapter;

internal class JsonParser<T> : IJsonParser<T>
{
    JsonSerializerOptions SerializerOptions => new() { WriteIndented = true };

    public T Parse(string data)
    {
        ArgumentNullException.ThrowIfNull(data);
        return JsonSerializer.Deserialize<T>(data);
    }

    public string ConvertToJson(T obj)
    {
        return JsonSerializer.Serialize(obj, SerializerOptions);
    }
}
