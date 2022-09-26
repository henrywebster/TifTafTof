using Game.GameOverFs;
using Godot;

public class GameOver : GameOverFs
{
    [Signal]
    public delegate void Next(string sceneFile);
}
