using System.Xml.Serialization;

namespace AdapterPattern.SimpleAdapter;

internal class XmlParser<T> : IXmlParser<T>
{
    private XmlSerializer _serializer => new XmlSerializer(typeof(T), new XmlRootAttribute(typeof(T).Name.ToLower()));

    public T Parse(string data)
    {
        using TextReader reader = new StringReader(data);
        return (T)_serializer.Deserialize(reader);
    }

    public string ConvertToXml(T obj)
    {
        using StringWriter sw = new();
        _serializer.Serialize(sw, obj);

        return sw.ToString();
    }
}
