using Godot;
using Pillar;
using System;

public class PlayerSprite : Sprite
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    Vector2 _screenSize;
    Vector2 _radius;
    Vector2 _velocity;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        //var pos = GetPosition();
        
        for (var i = 0; i < 10; i++)
        {
            GD.Print("Creating PlayerSprite");
        }

        _screenSize = GetViewportRect().Size;
        Position = _screenSize / 2;
        _radius = Texture.GetSize() / 2;
        UniqueRandom.SetRandomSeed(DateTime.Now.Millisecond);
        var x = UniqueRandom.Rand(100f, 300f);
        var y = UniqueRandom.Rand(100f, 300f);

        var rot = UniqueRandom.Rand(-Mathf.PI, Mathf.PI);

        _velocity = new Vector2(x, y).Rotated(rot);
        
    }

    public override void _Process(float delta)
    {
        // Called every frame. Delta is time since last frame.
        // Update game logic here.
        Position += _velocity * delta;
        Rotation += Mathf.PI * delta;

        if (Position.x >= _screenSize.x - _radius.x)
        {
            Position = new Vector2(_screenSize.x - _radius.x, Position.y);
            _velocity.x = -_velocity.x;
        }

        if (Position.x <= _radius.x)
        {
            Position = new Vector2(_radius.x, Position.y);
            _velocity.x = -_velocity.x;
        }

        if (Position.y >= _screenSize.y - _radius.y)
        {
            Position = new Vector2(Position.x, _screenSize.y - _radius.y);
            _velocity.y = -_velocity.y;
        }

        if (Position.y <= _radius.y)
        {
            Position = new Vector2(Position.x, _radius.y);
            _velocity.y = -_velocity.y;
        }
    }
}
