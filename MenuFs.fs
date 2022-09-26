namespace Game.MenuFs

open Godot

type MenuFs() =
    inherit Node2D()

    member this._OnStartPressed() =
        this.EmitSignal("Next", "res://Play.tscn")

    override this._Ready() =
        this
            .GetNode("Button")
            .Connect("pressed", this, nameof this._OnStartPressed)
        |> ignore

        ()
