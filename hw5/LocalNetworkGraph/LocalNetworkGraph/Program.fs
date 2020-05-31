// Learn more about F# at http://fsharp.org

open System
open LocalNetwork

[<EntryPoint>]
let main argv =
    printfn "%A" <|  LocalNetwork([[1; 3]; [0]; [3]; [2; 1]], ["Windows"; "Linux"; "Linux"; "Mac OS"], 
            [0.7; 0.1; 0.1; 0.9]).Infected

    0 // return an integer exit code
