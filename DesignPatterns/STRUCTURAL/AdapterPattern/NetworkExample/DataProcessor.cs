namespace AdapterPattern.NetworkExample;

internal class DataProcessor : IDataProcessor
{
    public bool DataProcess()
    {
        WriteLine($"Processed data");
        return true;
    }

    public void SendNetworkRequest(string ipAddress, string apiKey)
    {
        WriteLine($"Send network request with IP that requires API key: {ipAddress}");
    }
}
