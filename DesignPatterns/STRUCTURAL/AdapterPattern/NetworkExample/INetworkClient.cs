namespace AdapterPattern.NetworkExample;

internal interface INetworkClient
{
    public void SendRequest(string ipAddress);
}
