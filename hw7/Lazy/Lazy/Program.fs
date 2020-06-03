// Learn more about F# at http://fsharp.org

open System
open ILazy
open Lazy
open LazyFactory

[<EntryPoint>]
let main argv =
    let lz = new LazyFactory<int>()
    let sq x = x * x

    printfn "%A" <| lz.CreateSingleThreadedLazy(fun () -> sq 5)
    printfn "%A" <| lz.CreateSingleThreadedLazy(fun () -> sq 5)
    printfn "%A" <| lz.CreateSingleThreadedLazy(fun () -> sq 5)

    printfn "Hello World from F#!"


    0 // return an integer exit code
