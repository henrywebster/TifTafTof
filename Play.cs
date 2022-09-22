using Game.PlayFs;
using Godot;

public class Play : PlayFs
{
    [Signal]
    public delegate void Completed();

    [Signal]
    public delegate void Count();
}