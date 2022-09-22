namespace Game.GameFs

open System.Collections.Generic
open Godot

type TifTafTofFs() =
    inherit Node()

    let ScreenGenerator =
        let loadScene name =
            ResourceLoader.Load(name) :?> PackedScene
        let scenes = seq {"res://Menu.tscn"; "res://Play.tscn"; "res://GameOver.tscn"} |> Seq.map (loadScene)
        let mutable enumerator = (scenes).GetEnumerator()
        fun() ->
            match enumerator.MoveNext() with
            | true -> enumerator.Current
            | false -> enumerator <- (scenes).GetEnumerator(); enumerator.MoveNext() |> ignore; enumerator.Current

    let SceneStack = Stack<Node>()

    member this.addScene(scene: Node) =
            scene.Connect("Completed", this, nameof this.AdvanceScreen) |> ignore
            SceneStack.Push(scene)
            this.AddChild(scene)

    member this.removeScene scene =
        this.RemoveChild(scene)
        scene.QueueFree()

    member this.AdvanceScreen() =
        this.removeScene(SceneStack.Pop())
        this.addScene(ScreenGenerator().Instance())
        
    override this._Ready() =
        this.addScene(ScreenGenerator().Instance())
        