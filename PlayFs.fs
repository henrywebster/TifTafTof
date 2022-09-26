namespace Game.PlayFs

open Godot

type PlayFs() =
    inherit Node2D()

    let mutable counter = 0

    member this._OnDonePressed() =
        this.EmitSignal("Next", "res://GameOver.tscn")

    member this._OnCounterPressed() =
        counter <- counter + 1
        (this.GetNode("Label") :?> Label).Text <- counter.ToString()
        ()

    member this._OnQuitPressed() =
        this.EmitSignal("Next", "res://Menu.tscn")

    override this._Ready() =
        this
            .GetNode("ButtonDone")
            .Connect("pressed", this, nameof this._OnDonePressed)
        |> ignore

        this
            .GetNode("ButtonCounter")
            .Connect("pressed", this, nameof this._OnCounterPressed)
        |> ignore

        this
            .GetNode("ButtonQuit")
            .Connect("pressed", this, nameof this._OnQuitPressed)
        |> ignore

        ()
