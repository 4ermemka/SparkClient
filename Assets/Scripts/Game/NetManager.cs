using Assets.Scripts.Shared.Networking;
using Assets.Scripts.Shared.Tools;
using System;

public class NetManager
{
    public Action<string> OnConnectedToServer;
    public Action<string> OnDisconnectedFromServer;

    public Action<NetMsg> OnNetMsg;
    private Client _client;
    private NetMessageHandler _handler;


    public NetManager()
    {
        _client = new Client();
        _client.OnReceiveMessage += OnDataFromServer;
        _client.OnConnectedToServer += new Action(() =>
        {
            ConsoleLogger.LogInformation("NetManager", $"Connected to server: {_client.ConnectionAddress}");
            OnConnectedToServer?.Invoke($"Connected to server: {_client.ConnectionAddress}");
        });

        _client.OnConnectionToServerRefused += new Action(() =>
        {
            ConsoleLogger.LogWarning("Client", $"Cannot connect to server: {_client.ConnectionAddress}");
            OnDisconnectedFromServer?.Invoke($"Cannot connect to server: {_client.ConnectionAddress}");
        });

        _client.OnDisconnectedFromServer += new Action(() => 
        {
            ConsoleLogger.LogWarning("Client", $"Disconnected from server: {_client.ConnectionAddress}");
            OnDisconnectedFromServer?.Invoke($"Disconnected from server: {_client.ConnectionAddress}");
        });

        _handler = new NetMessageHandler();
    }

    public void Connect()
    {
        try
        {
            _client.Connect("127.0.0.28", 3535);
        }
        catch (Exception ex)
        {
            ConsoleLogger.LogException("NetManager", ex);
        }
    }

    public void OnDataFromServer(byte[] bytes)
    {
        NetMsg msg = NetMessagesParser.ParseBytes(bytes);
        ConsoleLogger.LogInformation("Client", $"Got data from server {msg.OP}");

        OnNetMsg?.Invoke(msg);
        _handler.Handle(msg);
    }

    public void Disconnect()
    {
        _client?.Stop();
        OnDisconnectedFromServer?.Invoke($"Disconnected from server {_client.ConnectionAddress}");
    }
}