// Learn more about F# at http://fsharp.org

open System
open LocalNetwork

[<EntryPoint>]
let main argv =
    printfn "%A" <| LocalNetwork([[1]; [0]], ["Linux"; "Windows"], [0.3; 0.7]).Infected
    0 // return an integer exit code
