// Learn more about F# at http://fsharp.org

open System
open PhonebookLogic

[<EntryPoint>]
let main argv =
    printfn "%A" (List.head (List.head (readInfoFromFile "Phonebook.txt" [])))


    0 // return an integer exit code
