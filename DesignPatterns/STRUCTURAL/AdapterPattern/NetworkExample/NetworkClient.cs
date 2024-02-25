namespace AdapterPattern.NetworkExample;

internal class NetworkClient : INetworkClient
{
    public void SendRequest(string ipAddress)
    {
        WriteLine($"Network clien request sent to IP: {ipAddress}");
    }
}
