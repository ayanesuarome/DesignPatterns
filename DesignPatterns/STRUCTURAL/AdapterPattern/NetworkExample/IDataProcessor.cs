namespace AdapterPattern.NetworkExample;

internal interface IDataProcessor
{
    public bool DataProcess();
    public void SendNetworkRequest(string ipAddress, string apiKey);
}
