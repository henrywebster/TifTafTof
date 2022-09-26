using Game.PlayFs;
using Godot;

public class Play : PlayFs
{
    [Signal]
    public delegate void Next(string sceneFile);

    [Signal]
    public delegate void Count();
}