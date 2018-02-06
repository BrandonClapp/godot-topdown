using Godot;
using System;

public class Player : Character
{
    private Vector2 _velocity;

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
                //Warp();
                // SendWarpRequest
                
            }
        }
    }
}
