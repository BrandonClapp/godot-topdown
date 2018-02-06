using Godot;
using Pillar.Network;
using System;

public class Server : Node
{
    private NetworkAdapter _network;
    private Label _connLabel;
    private string _ip = "127.0.0.1";
    private int _port = 33333;

    public override void _Ready()
    {
        _connLabel = (Label)GetNode("UI/Label");

        Log($"Creating server at {_ip}:{_port}");
        var host = new NetworkedMultiplayerENet
        {
            CompressionMode = NetworkedMultiplayerENet.CompressionModeEnum.Zlib
        };

        var error = host.CreateServer(_port, maxClients: 32);
 
        if (error != Error.Ok)
        {
            Log($"Could not create server. Error: {error}");
        }
        else Log("Server created");

        GetTree().SetNetworkPeer(host);

        GetTree().Connect("network_peer_connected", this, nameof(PeerConnected));
    }

    private void Log(string msg)
    {
        _connLabel.Text += $"{msg} \t\r\n\r\n";
    }

    private void PeerConnected(int id)
    {
        Log("Peer Connected " + id);
    }
}
