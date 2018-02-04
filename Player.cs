using Godot;
using System;

public class Player : KinematicBody2D
{
    private Vector2 _velocity;
    private Vector2 _screenSize;
    private int _speed = 300;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        _screenSize = GetViewportRect().Size;
        //_collision = (CollisionShape2D)GetNode("Collision");
        Position = _screenSize / 2;
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.

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

        var newPos = _velocity * _speed * delta;
        MoveAndCollide(newPos);

    }
}






