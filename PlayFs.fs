namespace Game.PlayFs

open Godot

type PlayFs() =
    inherit Node2D()

    let mutable counter = 0

    member this._OnDonePressed() =
        this.EmitSignal("Completed")

    member this._OnCounterPressed() = 
        counter <- counter + 1
        (this.GetNode("Label") :?> Label).Text <- counter.ToString()
        ()

    override this._Ready() =
        this.GetNode("ButtonDone").Connect("pressed", this, nameof this._OnDonePressed) |> ignore
        this.GetNode("ButtonCounter").Connect("pressed", this, nameof this._OnCounterPressed) |> ignore
        ()