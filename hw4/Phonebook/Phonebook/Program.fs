// Learn more about F# at http://fsharp.org

open System
open PhonebookLogic
open System.IO

[<EntryPoint>]
let main argv =
    printfn "%A" (List.head (List.head (readInfoFromFile "..\\..\\..\\Phonebook.txt" [])))
    printfn "%s" (Directory.GetCurrentDirectory())


    0 // return an integer exit code
