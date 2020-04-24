open System
open GreatestPalindrome
open SuperMap

[<EntryPoint>]
let main argv =
    printfn "%d" greatestPalindrome
    printfn "%A" (superMap([1.0; 2.0; 3.0]))
    0
