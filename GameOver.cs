using Game.GameOverFs;
using Godot;

public class GameOver : GameOverFs
{
    [Signal]
    public delegate void Completed();
}
