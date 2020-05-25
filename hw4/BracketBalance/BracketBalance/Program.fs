open System
open BracketBalance

[<EntryPoint>]
let main argv =
    printfn "%b" (bracketsAreInBalance "!")
    0
