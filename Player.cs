using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _velocity;
    private Vector2 _screenSize;
    private int _speed = 300;
    private AnimatedSprite _sprite;
    private bool _isInteractable;
    private int _dest_x;
    private int _dest_y;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        _screenSize = GetViewportRect().Size;
        _sprite = (AnimatedSprite)GetNode("Sprite");
        Position = _screenSize / 2;
    }

    public override void _Process(float delta)
    {
        ProcessMovement(delta);
        ProcessInteraction();
    }

    private void ProcessMovement(float delta)
    {
        if (Input.IsActionPressed("ui_up"))
        {
            _velocity = new Vector2(0, -1);
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            _velocity = new Vector2(0, 1);
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            _velocity = new Vector2(-1, 0);
        }
        else if (Input.IsActionPressed("ui_right"))
        {
            _velocity = new Vector2(1, 0);
        }
        else
        {
            _velocity = new Vector2();
        }

        if (_velocity.x > 0)
        {
            //_sprite.Play("right");
            //_sprite.FlipH = false;
            _sprite.RotationDegrees = 0;
        }
        else if (_velocity.x < 0)
        {
            //_sprite.Play("right");
            //_sprite.FlipH = true;
            _sprite.RotationDegrees = -180;
        }

        if (_velocity.y > 0)
        {
            //_sprite.Play("up");
            //_sprite.FlipV = true;
            _sprite.RotationDegrees = 90;
        }
        else if (_velocity.y < 0)
        {
            //_sprite.Play("up");
            //_sprite.FlipV = false;
            _sprite.RotationDegrees = -90;
        }

        var newPos = _velocity * _speed * delta;
        MoveAndCollide(newPos);
    }

    private void ProcessInteraction()
    {
        if (Input.IsActionJustPressed("ui_interact"))
        {
            if (_isInteractable)
            {
                GD.Print($"Warping to {_dest_x}x{_dest_y}");
                Warp(_dest_x, _dest_y);
                _dest_x = 0;
                _dest_y = 0;
            }
        }

        
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

    private void Warp(int x, int y)
    {
        Visible = false;
        Position = new Vector2(x, y);
        Visible = true;
    }
}
