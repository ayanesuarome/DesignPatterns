namespace AdapterPattern.SimpleAdapter;

// Adapter
internal class XmlToJsonAdapter<T> : IJsonParser<T>
{
    private IXmlParser<T> _xmlParser => new XmlParser<T>();
    private IJsonParser<T> _jsonParser => new JsonParser<T>();

    public T Parse(string data)
    {
        return _xmlParser.Parse(data);
    }

    public string ConvertToJson(T obj)
    {
        return _jsonParser.ConvertToJson(obj);
    }
}
