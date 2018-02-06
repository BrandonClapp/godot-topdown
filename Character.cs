using Godot;
using System;

public class Character : KinematicBody2D
{
    protected AnimatedSprite _sprite;
    protected bool _isInteractable;
    protected int _speed = 300;

    private int _dest_x;
    private int _dest_y;
    private Vector2 _screenSize;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        _screenSize = GetViewportRect().Size;
        _sprite = (AnimatedSprite)GetNode("Sprite");
        Position = _screenSize / 2;
    }

    private void _on_Interaction_area_shape_entered(int area_id, Godot.Object area, int area_shape, int self_shape)
    {
        GD.Print($"Entered area. {area} - {area_shape} - {self_shape}");
        var map = (string)area.GetMeta("dest_map");
        var x = (int)area.GetMeta("dest_tile_x");
        var y = (int)area.GetMeta("dest_tile_y");

        GD.Print($"Tele to: {x}x{y}");
        _isInteractable = true;

        _dest_x = x;
        _dest_y = y;
    }

    private void _on_Interaction_area_shape_exited(int area_id, Godot.Object area, int area_shape, int self_shape)
    {
        GD.Print($"Exited area. {area} - {area_shape} - {self_shape}");
        _isInteractable = false;
        _dest_x = 0;
        _dest_y = 0;
    }

    protected void Warp(int x, int y)
    {
        Visible = false;
        Position = new Vector2(x, y);
        Visible = true;
    }
}
