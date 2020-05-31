// Learn more about F# at http://fsharp.org

open System
open LocalNetwork

[<EntryPoint>]
let main argv =
    printfn "%A" <|  LocalNetwork([[1; 2; 3; 4]; [0; 2; 3; 4]; [0; 1; 3; 4]; [0; 1; 2; 3]; [0; 1; 2; 3; 4]], 
        ["WIndows"; "Windows"; "Linux"; "Linux"; "Mac OS"], [0.5; 0.5; 0.2; 0.2; 1.0]).Infected

    0 // return an integer exit code
