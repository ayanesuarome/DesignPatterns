namespace AdapterPattern.NetworkExample;

internal class NetworkAdapter(IDataProcessor dataProcessor) : INetworkClient
{
    private readonly IDataProcessor _dataProcessor = dataProcessor;

    public void SendRequest(string ipAddress)
    {
        var apiKey = "apikey";
        _dataProcessor.SendNetworkRequest(ipAddress, apiKey);
    }
}
