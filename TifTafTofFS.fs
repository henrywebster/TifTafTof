namespace Game.GameFs

open Godot



type TifTafTofFs() =
    inherit Node()

    let createSceneInstanceFromResource (sceneFile) =
        (ResourceLoader.Load(sceneFile) :?> PackedScene)
            .Instance()

    member val currentScreen = createSceneInstanceFromResource "res://Menu.tscn" with get, set

    member this.addScene(scene: Node) =
        scene.Connect("Next", this, nameof this.advanceScreen)
        |> ignore

        this.currentScreen <- scene
        this.AddChild(scene)

    member this.removeScene scene =
        this.RemoveChild(scene)
        scene.QueueFree()

    member this.advanceScreen(resourceFile: string) =
        this.removeScene (this.currentScreen)
        let nextScreen = createSceneInstanceFromResource resourceFile
        this.addScene (nextScreen)

    override this._Ready() = this.addScene (this.currentScreen)
