namespace AdapterPattern.SimpleAdapter;

// Adaptee
internal interface IXmlParser<T>
{
    public T Parse(string data);
    public string ConvertToXml(T obj);
}
