namespace AdapterPattern.SimpleAdapter;

internal interface IJsonParser<T>
{
    public T Parse(string data);
    public string ConvertToJson(T obj);
}
