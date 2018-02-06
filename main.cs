using Godot;
using Pillar;
using Pillar.Network;
using System;

public class main : Node
{
    NetworkAdapter _network;
    private string _ip = "127.0.0.1";
    private int _port = 33333;

    public override void _Ready()
    {
        GD.Print($"Attemping to join server at {_ip}:{_port}");
        var client = new NetworkedMultiplayerENet
        {
            CompressionMode = NetworkedMultiplayerENet.CompressionModeEnum.Zlib
        };

        var error = client.CreateClient(_ip, _port);
        if (error != Error.Ok)
        {
            GD.Print($"Could not connect to server. Error: {error}");
        }
        else GD.Print($"Successfully connected to {_ip}:{_port}.");

        GetTree().SetNetworkPeer(client);

        //GetTree().Connect("peer_connected", this, "PeerConnected");
    }

    public override void _Process(float delta)
    {

    }
}