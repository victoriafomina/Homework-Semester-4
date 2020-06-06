module PhonebookLogic

open System.IO
open Microsoft.FSharp.Core.Operators
open System

/// Reads the notes from file.
let readInfoFromFile (fileName : string) =

    let splitIntoListOfStrings (str : string) = str.Split [|' '|] |> Array.toList

    let toPairOfString list = (List.head list, List.last list)

    let parse arrStr =
        let rec parseRec arrStr store =
            match arrStr with
            | [] -> store
            | h :: t -> parseRec t ((h |> splitIntoListOfStrings |> toPairOfString ) :: store)
        parseRec arrStr []

    try
        fileName |> File.ReadAllLines |> Array.toList  |> parse
    with | _ -> failwith "File was not opened or was not handled!"

/// Saves the current data to the file.
let saveCurrentData (fileName : string) data =
    let parse listListStr = 
        let rec parseRec listListStr listStr =
            match listListStr with
            | [] -> listStr
            | h :: t -> parseRec t ([List.head h; List.last h] :: listStr)
        parseRec listListStr []
                
    try
        File.AppendAllLines(fileName, parse data)
    with | _ -> failwith "File was not opened or was not handled!"

/// Add note (name and number).
let addNote (name : string) (number : string) = [name; number]

/// Prints the database.
let printDatabase store =
    let printList x =
        printf "%s%s" (List.head x) " "  
        printfn "%s" (List.last x)

    List.iter (fun x -> printList x) store

/// Checks if the name exists.
let nameExists name store =
    List.exists (fun x -> List.head x = name) store

/// Checks if the number exists.
let numberExists number store =
    List.exists (fun x -> List.last x = number) store

/// Finds a number by the name.
let findNumberByName name store =
    if nameExists name store then Some(List.find (fun x -> List.head x = name) store |> List.last)
    else None

/// Finds a name by the number.
let findNameByNumber number store =
    if numberExists number store then Some(List.find (fun x -> List.last x = number) store |> List.head)
    else None