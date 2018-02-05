using Godot;
using Pillar;
using System;

public class main : Node
{
    Node _player;
    Vector2 _screenSize;

    public override void _Ready()
    {
        _screenSize = GetViewport().GetVisibleRect().Size;
        _player = GetNode("Player");
    }

    public override void _Process(float delta)
    {

    }
}