// Learn more about F# at http://fsharp.org

open System
open PhonebookLogic
open System.IO

[<EntryPoint>]
let main argv =
    saveCurrentData "..\\..\\..\\Phonebook.txt" [["lol"; "123"]]
    printfn "%A" (List.head (List.head (readInfoFromFile "..\\..\\..\\Phonebook.txt" [])))


    0 // return an integer exit code
