using Game.MenuFs;
using Godot;

public class Menu : MenuFs
{
    [Signal]
    public delegate void Next(string sceneFile);
}
