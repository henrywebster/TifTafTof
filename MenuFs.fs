namespace Game.MenuFs

open Godot

type MenuFs() =
    inherit Node2D()

    member this._OnPressed() =
        this.EmitSignal("Completed")

    override this._Ready() =
        this.GetNode("Button").Connect("pressed", this, nameof this._OnPressed) |> ignore
        ()