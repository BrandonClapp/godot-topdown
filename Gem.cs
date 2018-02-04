using Godot;
using System;

public class Gem : Area2D
{

    private const string GemGrabbed = "gem_grabbed";
    private Sprite _sprite;
    private Tween _effect;
    private Tween _enterEffect;

    public override void _Ready()
    {
        _sprite = (Sprite)GetNode("Sprite");
        _effect = (Tween)GetNode("Effect");
        _enterEffect = (Tween)GetNode("EnterEffect");

        _effect.InterpolateProperty(_sprite, "scale", _sprite.Scale,
            new Vector2(2.0f, 2.0f), 0.3f, Tween.TransitionType.Quad, Tween.EaseType.Out);

        _effect.InterpolateProperty(_sprite, "modulate", new Color(1, 1, 1, 1),
            new Color(1, 1, 1, 0), 0.3f, Tween.TransitionType.Quad, Tween.EaseType.Out);

        _enterEffect.InterpolateProperty(_sprite, "scale", new Vector2(0f, 0f),
            new Vector2(1f, 1f), 0.2f, Tween.TransitionType.Bounce, Tween.EaseType.In);

        _enterEffect.InterpolateProperty(_sprite, "modulate", new Color(1, 1, 1, 0),
            new Color(1, 1, 1, 1), 0.2f, Tween.TransitionType.Bounce, Tween.EaseType.In);

        _enterEffect.Start();

        AddUserSignal(GemGrabbed);
    }

    //    public override void _Process(float delta)
    //    {
    //        // Called every frame. Delta is time since last frame.
    //        // Update game logic here.
    //        
    //    }

    private void _on_Gem_area_entered(Godot.Object area)
    {
        if ((string)area.Get("Name") == "Player")
        {
            EmitSignal(GemGrabbed);
            _effect.Start();
            var owners = GetShapeOwners();
            ShapeOwnerClearShapes((int)owners[0]);
        }
    }

    private void _on_Effect_tween_completed(Godot.Object @object, NodePath key)
    {
        QueueFree();
    }

    private void _on_EnterEffect_tween_completed(Godot.Object @object, NodePath key)
    {
        // Replace with function body
    }
}

