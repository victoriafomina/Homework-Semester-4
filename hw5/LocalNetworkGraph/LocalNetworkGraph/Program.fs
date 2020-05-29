// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    printfn "%d" <| (new Random()).Next(0, 9)
    printfn "%f" <| (new Random()).n
    0 // return an integer exit code
