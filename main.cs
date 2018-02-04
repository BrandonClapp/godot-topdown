using Godot;
using Pillar;
using System;

public class main : Node
{
    PackedScene _gem = ResourceLoader.Load(@"res://Gem.tscn") as PackedScene;
    Node _player;
    Node _gemContainer;
    Vector2 _screenSize;
    Label _scoreLabel;
    Label _timeLabel;
    Label _gameOver;
    Button _gameOverRetry;
    Timer _gameTimer;
    int _score = 0;
    int _level = 1;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        //AddChild(_player.Instance());
        _screenSize = GetViewport().GetVisibleRect().Size;
        _gemContainer = GetNode("Gem_Container");
        _player = GetNode("Player");
        _scoreLabel = (Label)GetNode("HUD/Score_Label");
        _timeLabel = (Label)GetNode("HUD/Time_Label");
        _gameTimer = (Timer)GetNode("Game_Timer");
        _gameOverRetry = (Button)GetNode("HUD/GameOver_Retry_Button");
        //SpawnGems(_level);
    }

    private void SpawnGems(int level)
    {
        for (var i = 0; i < level * 10; i++)
        {
            var g = _gem.Instance() as Area2D;
            _gemContainer.AddChild(g);
            g.Connect("gem_grabbed", this, nameof(GemGrabbed));
            g.Position = new Vector2(
                UniqueRandom.Rand(30, _screenSize.x - 30),
                UniqueRandom.Rand(30, _screenSize.y - 30)
                );
        }
    }

    public override void _Process(float delta)
    {
        _timeLabel.Text = $"Time: {((int)_gameTimer.GetTimeLeft()).ToString()}";
        _scoreLabel.Text = $"Score: {_score.ToString()}";
    }

    private void GemGrabbed()
    {
        _score += 10;        
    }

    private void ResetGame()
    {
        _gameOver.Visible = false;
        _gameOverRetry.Visible = false;
        _gameTimer.Start();
        _score = 0;
        _player.SetProcess(true);
        var gems = _gemContainer.GetChildren();
        foreach (var gem in gems)
        {
            ((Node)gem).QueueFree();
        }
        _level = 1;
        SpawnGems(1);
    }

    private void _on_Game_Timer_timeout()
    {
        _player.SetProcess(false);
        _gameOver = (Label)GetNode("HUD/GameOver_Label");
        _gameOverRetry = (Button)GetNode("HUD/GameOver_Retry_Button");
        _gameOverRetry.Visible = true;
        _gameOver.Visible = true;
    }

    private void _on_GameOver_Retry_Button_pressed()
    {
        ResetGame();
    }
}