namespace Game.GameOverFs

open Godot

type GameOverFs() =
    inherit Node2D()

    member this._OnPressed() =
        this.EmitSignal("Next", "res://Menu.tscn")


    override this._Ready() =
        this
            .GetNode("Button")
            .Connect("pressed", this, nameof this._OnPressed)
        |> ignore

        ()
